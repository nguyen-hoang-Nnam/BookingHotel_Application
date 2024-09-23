using BookingHotel_Application.Model.Models.DTO;
using BookingHotel_Application.Model.Models.DTO.Hotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel_Application.BLL.Service.IService
{
    public interface IHotelService
    {
        Task<ResponseDTO> GetAllHotelsAsync();
        Task<ResponseDTO> GetHotelByIdAsync(int hotelid);
        Task<ResponseDTO> CreateHotelAsync(CreateHotelDTO createHotelDTO);
        Task<ResponseDTO> UpdateHotelAsync(int hotelid, UpdateHotelDTO updateHotelDTO);
        Task<ResponseDTO> DeleteHotelAsync(int hotelid);
    }
}
