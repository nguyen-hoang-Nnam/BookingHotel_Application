using BookingHotel_Application.Model.Models.DTO.Countries;
using BookingHotel_Application.Model.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingHotel_Application.Model.Models.DTO.RoomType;

namespace BookingHotel_Application.BLL.Service.IService
{
    public interface IRoomTypeService
    {
        Task<ResponseDTO> GetAllRoomTypeAsync();
        Task<ResponseDTO> GetRoomTypeByIdAsync(int roomtypeid);
        Task<ResponseDTO> CreateRoomTypeAsync(CreateRoomTypeDTO createRoomTypeDTO);
        Task<ResponseDTO> UpdateRoomTypeAsync(int roomtypeid, UpdateRoomTypeDTO updateRoomTypeDTO);
        Task<ResponseDTO> DeleteRoomTypeAsync(int roomtypeid);
    }
}
