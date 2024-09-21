using AutoMapper;
using BookingHotel_Application.BLL.Service.IService;
using BookingHotel_Application.DAL.Repository.IRepository;
using BookingHotel_Application.DAL.UoW.IUoW;
using BookingHotel_Application.Model.Enum;
using BookingHotel_Application.Model.Models.DTO;
using BookingHotel_Application.Model.Models.DTO.Customer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel_Application.BLL.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            this._mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public Task<ResponseDTO> CreateCustomerAsync(CustomerDTO customerDto)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDTO> DeleteCustomerAsync(int id)
        {
            var response = new ResponseDTO();
            try
            {
                var existingCustomer = await _unitOfWork.CustomerRepository.GetByIdAsync(id);
                if (existingCustomer == null)
                {
                    response.Message = "Customer not found";
                    return response;
                }

                await _customerRepository.DeleteAsync(id);
                response.IsSucceed = true;
                response.Message = "Customer deleted successfully";
            }
            catch (Exception ex)
            {
                response.Message = $"Error: {ex.Message}";
            }

            return response;
        }

        public async Task<ResponseDTO> GetAllCustomersAsync()
        {
            var response = new ResponseDTO();
            try
            {
                var customers = await _unitOfWork.CustomerRepository.GetAll();
                response.IsSucceed = true;
                response.Data = _mapper.Map<IEnumerable<CustomerDTO>>(customers);
            }
            catch (Exception ex)
            {
                response.Message = $"Error: {ex.Message}";
            }

            return response;
        }

        public async Task<ResponseDTO> GetCustomerByIdAsync(int id)
        {
            var response = new ResponseDTO();
            try
            {
                var customer = await _unitOfWork.CustomerRepository.GetById(id);
                if (customer == null)
                {
                    response.Message = "Customer not found";
                    return response;
                }
                response.IsSucceed = true;
                response.Data = _mapper.Map<CustomerDTO>(customer);
            }
            catch (Exception ex)
            {
                response.Message = $"Error: {ex.Message}";
            }

            return response;
        }

        public async Task<ResponseDTO> UpdateCustomerAsync(int id, UpdateCustomerDTO customerDto)
        {
            var response = new ResponseDTO();
            try
            {
                var existingCustomer = await _unitOfWork.CustomerRepository.GetByIdAsync(id);
                if (existingCustomer == null)
                {
                    response.Message = "Customer not found";
                    return response;
                }

                _mapper.Map(customerDto, existingCustomer);
                var updated = await _unitOfWork.CustomerRepository.UpdateAsync(existingCustomer);
                if (updated)
                {
                    response.IsSucceed = true;
                    response.Message = "Customer updated successfully";
                    response.Data = customerDto;
                }
            }
            catch (Exception ex)
            {
                response.Message = $"Error: {ex.Message}";
            }

            return response;
        }
        public async Task<ResponseDTO> BanCustomerAsync(int customerId)
        {
            var response = new ResponseDTO();
            try
            {
                var existingCustomer = await _unitOfWork.CustomerRepository
                    .GetAllIncluding(c => c.User) // This returns IQueryable<Customer>
                    .FirstOrDefaultAsync(c => c.customerId == customerId); // Now we can use FirstOrDefaultAsync

                if (existingCustomer == null)
                {
                    response.Message = "Customer not found";
                    return response;
                }

                var user = existingCustomer.User;
                if (user == null)
                {
                    response.Message = "User not found for this customer";
                    return response;
                }

                user.Status = UserStatus.Banned;
                await _unitOfWork.UserRepository.UpdateAsync(user);

                response.IsSucceed = true;
                response.Message = "Customer banned successfully";
            }
            catch (Exception ex)
            {
                response.Message = $"Error: {ex.Message}";
            }

            return response;
        }
        
        public async Task<ResponseDTO> UnBanCustomerAsync(int customerId)
        {
            var response = new ResponseDTO();
            try
            {
                var existingCustomer = await _unitOfWork.CustomerRepository
                    .GetAllIncluding(c => c.User)
                    .FirstOrDefaultAsync(c => c.customerId == customerId);

                if (existingCustomer == null)
                {
                    response.Message = "Customer not found";
                    return response;
                }

                var user = existingCustomer.User;
                if (user == null)
                {
                    response.Message = "User not found for this customer";
                    return response;
                }

                user.Status = UserStatus.Active;
                await _unitOfWork.UserRepository.UpdateAsync(user);

                response.IsSucceed = true;
                response.Message = "Customer Unbaned successfully";
            }
            catch (Exception ex)
            {
                response.Message = $"Error: {ex.Message}";
            }

            return response;
        }



    }
}
