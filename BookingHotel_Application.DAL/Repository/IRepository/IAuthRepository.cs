using BookingHotel_Application.Model.Models;
using BookingHotel_Application.Model.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel_Application.DAL.Repository.IRepository
{
    public interface IAuthRepository : IGenericRepository<User>
    {
        Task<User?> GetByUserName(string userName);
    }
}
