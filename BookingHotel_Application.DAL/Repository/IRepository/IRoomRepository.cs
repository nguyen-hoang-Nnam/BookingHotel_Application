using BookingHotel_Application.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel_Application.DAL.Repository.IRepository
{
    public interface IRoomRepository : IGenericRepository<Room>
    {
        Task<IEnumerable<Room>> GetAll();
        Task<Room?> GetById(int hotelid);
        Task<IEnumerable<Room>> GetRoomByRoomTypeIdAsync(int roomTypeId);
        Task<IEnumerable<Room>> GetRoomByHotelIdAsync(int hotelId);
    }
}
