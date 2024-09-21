using BookingHotel_Application.DAL.Repository.IRepository;
using BookingHotel_Application.Model.Data;
using BookingHotel_Application.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel_Application.DAL.Repository
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly AppDbContext _appDbContext;

        public CustomerRepository(AppDbContext appDbContext) : base(appDbContext)
        {
           _appDbContext = appDbContext;
        }

        public async Task<Customer?> GetById(int customerId)
        {
            return await _appDbContext.Customers
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.customerId == customerId);
        }
        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _appDbContext.Customers.Include(c => c.User).ToListAsync();
        }
        public async Task<bool> UpdateAsync(User user)
        {
            _appDbContext.Users.Update(user);
            return await _appDbContext.SaveChangesAsync() > 0;
        }
        public IQueryable<Customer> GetAllIncluding(params Expression<Func<Customer, object>>[] includeProperties)
        {
            IQueryable<Customer> query = _appDbContext.Set<Customer>();

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }
    }

}
