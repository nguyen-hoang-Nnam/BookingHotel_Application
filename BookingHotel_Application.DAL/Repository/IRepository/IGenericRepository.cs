using BookingHotel_Application.Model.Commons;
using BookingHotel_Application.Model.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel_Application.DAL.Repository.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task DeleteAsync(string id);
        Task<T> GetByIdAsync(string id);
        Task<Pagination<T>> ToPagination(PaginationParameter paginationParameter);
    }
}
