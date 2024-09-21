using BookingHotel_Application.DAL.Repository.IRepository;
using BookingHotel_Application.Model.Data;
using BookingHotel_Application.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel_Application.DAL.Repository
{
    public class StaffRepository : GenericRepository<Staff>, IStaffRepository
    {
        private readonly AppDbContext _appDbContext;

        public StaffRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
    {
    }
}
