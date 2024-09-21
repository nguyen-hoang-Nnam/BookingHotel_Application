using AutoMapper;
using BookingHotel_Application.BLL.Service.IService;
using BookingHotel_Application.DAL.Repository;
using BookingHotel_Application.DAL.Repository.IRepository;
using BookingHotel_Application.Model.Helper;
using BookingHotel_Application.Model.Models;
using BookingHotel_Application.Model.Models.DTO;
using BookingHotel_Application.Model.Models.DTO.Auth;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel_Application.BLL.Service
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IConfiguration _configuration;
        private readonly ICustomerRepository _customerRepository;
        private IMapper _mapper;
        private JwtHelper _jwtHelper;

        public AuthService(IAuthRepository authRepository, IConfiguration configuration, IMapper mapper, JwtHelper jwtHelper, ICustomerRepository customerRepository)
        {
            _authRepository = authRepository;
            _configuration = configuration;
            _mapper = mapper;
            _jwtHelper = jwtHelper;
            _customerRepository = customerRepository;
        }

        // Login
        public async Task<ResponseDTO> LoginUserAsync(UserLoginDTO userLoginDTO)
        {
            var response = new ResponseDTO();

            var user = await _authRepository.GetByUserName(userLoginDTO.userName);
            if (user == null)
            {
                response.Message = "Invalid credentials";
                return response;
            }

            var isPasswordValid = VerifyPassword(userLoginDTO.Password, user.passwordHash);

            if (!isPasswordValid)
            {
                response.Message = "Invalid credentials";
                return response;
            }

            var token = _jwtHelper.GenerateJwtToken(user);
            var refreshToken = _jwtHelper.GenerateRefreshToken();

            user.refreshToken = refreshToken;
            await _authRepository.UpdateAsync(user);

            response.IsSucceed = true;
            response.Message = "Login successful";
            response.Data = new { Token = token, RefreshToken = refreshToken };

            return response;
        }


        // Register
        public async Task<ResponseDTO> RegisterUserAsync(UserRegisterDTO userRegisterDTO)
        {
            var response = new ResponseDTO();

            var existingUser = await _authRepository.GetByUserName(userRegisterDTO.userName);
            if (existingUser != null)
            {
                response.Message = "User already exists";
                return response;
            }

            var user = _mapper.Map<User>(userRegisterDTO);

            user.userId = GenerateUniqueId();
            user.passwordHash = HashPassword(userRegisterDTO.Password);
            user.Status = Model.Enum.UserStatus.Active;
            user.Role = Model.Enum.UserRole.Customer;

            await _authRepository.AddAsync(user);

            var customer = new Customer
            {
                customerId = 0,
                User = user
            };

            // Add the customer to the database
            await _customerRepository.AddAsync(customer);

            response.IsSucceed = true;
            response.Message = "Registration successful";
            response.Data = _mapper.Map<UserRegisterDTO>(user);
            return response;
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        private bool VerifyPassword(string enteredPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(enteredPassword, hashedPassword);
        }
        private string GenerateUniqueId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
