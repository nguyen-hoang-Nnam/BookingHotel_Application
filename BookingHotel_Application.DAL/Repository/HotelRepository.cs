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
    public class HotelRepository : GenericRepository<Hotel> , IHotelRepository
    {
        private readonly AppDbContext _appDbContext;

        public HotelRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Hotel>> GetAll()
        {
            return await _appDbContext.Hotels.Include(h => h.Countries).ToListAsync();
        }
        public async Task<Hotel?> GetById(int id)
        {
            return await _appDbContext.Hotels.Include(h => h.Countries)
                                      .FirstOrDefaultAsync(h => h.hotelId == id);
        }
        public async Task<IEnumerable<Hotel>> GetHotelsByCountryIdAsync(int countryId)
        {
            return await _appDbContext.Hotels
                .Include(hotel => hotel.Countries)
                .Where(hotel => hotel.Countries != null && hotel.Countries.countryId == countryId)
                .ToListAsync();
        }
        public async Task<Hotel> GetHotelWithRoomsAndCommentsAsync(int hotelId)
        {
            return await _appDbContext.Hotels
                .Include(h => h.Countries)
                .Include(h => h.Rooms)
                    .ThenInclude(r => r.RoomType)
                .Include(h => h.Comments)
                    .ThenInclude(c => c.User)
                .FirstOrDefaultAsync(h => h.hotelId == hotelId);
        }
    }
}
