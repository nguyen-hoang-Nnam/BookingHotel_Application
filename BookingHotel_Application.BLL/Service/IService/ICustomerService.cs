using BookingHotel_Application.Model.Models.DTO.Customer;
using BookingHotel_Application.Model.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel_Application.BLL.Service.IService
{
    public interface ICustomerService
    {
        Task<ResponseDTO> GetAllCustomersAsync();
        Task<ResponseDTO> GetCustomerByIdAsync(int id);
        Task<ResponseDTO> CreateCustomerAsync(CustomerDTO customerDto);
        Task<ResponseDTO> UpdateCustomerAsync(int id, UpdateCustomerDTO customerDto);
        Task<ResponseDTO> DeleteCustomerAsync(int id);
        Task<ResponseDTO> BanCustomerAsync(int customerId);
        Task<ResponseDTO> UnBanCustomerAsync(int customerId);
    }
}
