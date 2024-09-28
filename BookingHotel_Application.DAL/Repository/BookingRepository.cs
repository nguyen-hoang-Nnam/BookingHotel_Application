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
    public class BookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        private readonly AppDbContext _appDbContext;

        public BookingRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Booking>> GetAll()
        {
            return await _appDbContext.Bookings
                .Include(b => b.User)
                .Include(b => b.Room)
                .ToListAsync();
        }

        public async Task<Booking> GetById(int id)
        {
            return await _appDbContext.Bookings
                .Include(b => b.User)
                .Include(b => b.Room)
                .FirstOrDefaultAsync(b => b.bookingId == id);
        }



        public async Task<IEnumerable<Booking>> GetBookingsByUserIdAsync(string userId)
        {
            return await _appDbContext.Bookings
                .Where(b => b.userId == userId)
                .Select(b => new Booking
                {
                    bookingId = b.bookingId,
                    bookingDate = b.bookingDate,
                    checkIn = b.checkIn,
                    checkOut = b.checkOut,
                    totalPrice = b.totalPrice,
                    bookingStatus = b.bookingStatus,
                    userId = b.userId,
                    User = new User
                    {
                        Email = b.User.Email,
                        phoneNumber = b.User.phoneNumber
                    },
                    roomId = b.roomId,
                    Room = new Room
                    {
                        roomName = b.Room.roomName,
                        pricePerDay = b.Room.pricePerDay,
                        roomSize = b.Room.roomSize
                    }
                })
                .ToListAsync();
        }
        public void Update(Booking booking)
        {
            _appDbContext.Bookings.Update(booking);
        }

    }
}
