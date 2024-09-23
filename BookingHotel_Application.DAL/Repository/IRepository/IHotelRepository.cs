using BookingHotel_Application.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel_Application.DAL.Repository.IRepository
{
    public interface IHotelRepository : IGenericRepository<Hotel>
    {
        Task<IEnumerable<Hotel>> GetAll();
        Task<Hotel?> GetById(int hotelid);
        Task<IEnumerable<Hotel>> GetHotelsByCountryIdAsync(int countryId);
    }
}
