using BookingHotel_Application.DAL.Repository.IRepository;
using BookingHotel_Application.Model.Data;
using BookingHotel_Application.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel_Application.DAL.Repository
{
    public class RoomRepository : GenericRepository<Room>, IRoomRepository
    {
        private readonly AppDbContext _appDbContext;

        public RoomRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Room>> GetAll()
        {
            return await _appDbContext.Rooms.Include(h => h.RoomType).Include(room => room.Hotel).ToListAsync();
        }
        public async Task<Room?> GetById(int id)
        {
            return await _appDbContext.Rooms.Include(h => h.RoomType)
                                      .FirstOrDefaultAsync(h => h.roomId == id);
        }
        public async Task<IEnumerable<Room>> GetRoomByRoomTypeIdAsync(int roomTypeId)
        {
            return await _appDbContext.Rooms
                .Include(hotel => hotel.RoomType)
                .Where(hotel => hotel.RoomType != null && hotel.RoomType.roomTypeId == roomTypeId)
                .ToListAsync();
        }
        public async Task<IEnumerable<Room>> GetRoomByHotelIdAsync(int hotelId)
        {
            return await _appDbContext.Rooms
                .Include(room => room.Hotel)
                .ThenInclude(hotel => hotel.Countries)
                .Include(room => room.RoomType)     
                .Where(room => room.Hotel != null && room.Hotel.hotelId == hotelId)
                .ToListAsync();
        }
    }
}
