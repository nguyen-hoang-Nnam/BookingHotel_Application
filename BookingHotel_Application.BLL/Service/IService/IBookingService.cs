using BookingHotel_Application.Model.Models.DTO.Booking;
using BookingHotel_Application.Model.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel_Application.BLL.Service.IService
{
    public interface IBookingService
    {
        Task<ResponseDTO> GetAllBookingsAsync();
        Task<ResponseDTO> GetBookingByIdAsync(int id);
        Task<ResponseDTO> CreateBookingAsync(CreateBookingDTO createBookingDTO);
        Task<ResponseDTO> UpdateBookingAsync(UpdateBookingDTO updateBookingDTO);
        Task<ResponseDTO> DeleteBookingAsync(int bookingId);
        Task<ResponseDTO> GetBookingsByUserId(string userId);
    }
}
