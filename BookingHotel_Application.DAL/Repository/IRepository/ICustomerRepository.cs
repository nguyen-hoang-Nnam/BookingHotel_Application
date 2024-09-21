using BookingHotel_Application.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel_Application.DAL.Repository.IRepository
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<Customer?> GetById(int customerId);
        Task<IEnumerable<Customer>> GetAll();
        IQueryable<Customer> GetAllIncluding(params Expression<Func<Customer, object>>[] includeProperties);
    }
}
