using BookingHotel_Application.Model.Models;
using BookingHotel_Application.Model.Models.DTO;
using BookingHotel_Application.Model.Models.DTO.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel_Application.BLL.Service.IService
{
    public interface IAuthService
    {
        Task<ResponseDTO> RegisterUserAsync(UserRegisterDTO userRegisterDTO);
        Task<ResponseDTO> LoginUserAsync(UserLoginDTO userLoginDTO);
    }
}
