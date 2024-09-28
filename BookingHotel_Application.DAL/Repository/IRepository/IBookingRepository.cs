using BookingHotel_Application.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel_Application.DAL.Repository.IRepository
{
    public interface IBookingRepository : IGenericRepository<Booking>
    {
        Task<IEnumerable<Booking>> GetAll();
        Task<Booking> GetById(int id);
        Task<IEnumerable<Booking>> GetBookingsByUserIdAsync(string userId);
        void Update(Booking booking);
    }
}
