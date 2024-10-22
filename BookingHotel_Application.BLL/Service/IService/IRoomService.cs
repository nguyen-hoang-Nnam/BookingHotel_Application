using BookingHotel_Application.Model.Models.DTO.Hotel;
using BookingHotel_Application.Model.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingHotel_Application.Model.Models.DTO.Room;

namespace BookingHotel_Application.BLL.Service.IService
{
    public interface IRoomService
    {
        Task<ResponseDTO> GetAllRoomAsync();
        Task<ResponseDTO> GetRoomByIdAsync(int roomid);
        Task<ResponseDTO> CreateRoomAsync(CreateRoomDTO createHotelDTO);
        Task<ResponseDTO> UpdateRoomAsync(int roomid);
        Task<ResponseDTO> DeleteRoomAsync(int roomid);
        Task<ResponseDTO> GetRoomsByRoomTypeIdAsync(int roomTypeId);
        Task<ResponseDTO> GetRoomsByHotelIdAsync(int hotelId);
    }
}
