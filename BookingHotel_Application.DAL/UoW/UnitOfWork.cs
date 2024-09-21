using BookingHotel_Application.DAL.Repository.IRepository;
using BookingHotel_Application.DAL.UoW.IUoW;
using BookingHotel_Application.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel_Application.DAL.UoW
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUserRepository _userRepository;
        private readonly AppDbContext _dbContext;
        private bool disposed = false;

        public UnitOfWork(ICustomerRepository customerRepository, AppDbContext dbContext, IUserRepository userRepository)
        {
            _customerRepository = customerRepository;
            _dbContext = dbContext;
            _userRepository = userRepository;
        }
        public ICustomerRepository CustomerRepository { get { return _customerRepository; } }
        public IUserRepository UserRepository { get { return _userRepository; } }

        public AppDbContext dbContext { get { return _dbContext; } }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
                disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<int> SaveChangeAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
