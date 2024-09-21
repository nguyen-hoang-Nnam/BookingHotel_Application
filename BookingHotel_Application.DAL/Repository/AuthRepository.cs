using BookingHotel_Application.DAL.Repository.IRepository;
using BookingHotel_Application.Model.Data;
using BookingHotel_Application.Model.Models;
using BookingHotel_Application.Model.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel_Application.DAL.Repository
{
    public class AuthRepository : GenericRepository<User>, IAuthRepository
    {
        private readonly AppDbContext _appDbContext;

        public AuthRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            {
                _appDbContext = appDbContext;
            }

        }

        public async Task<User?> GetByUserName(string userName)
        {
            return await _appDbContext.Users.SingleOrDefaultAsync(u => u.userName == userName);
        }
        
    }
}
