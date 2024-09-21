using BookingHotel_Application.DAL.Repository.IRepository;
using BookingHotel_Application.Model.Commons;
using BookingHotel_Application.Model.Data;
using BookingHotel_Application.Model.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel_Application.DAL.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        // ADD
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        // DELETE
        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }// DELETE String
        public async Task DeleteAsync(string id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }


        // GET ALL
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }


        //GET By string ID
        public async Task<T> GetByIdAsync(string id)
        {
            return await _dbSet.FindAsync(id);
        }


        //GET By int ID
        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }


        // UPDATE
        public async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                _dbSet.Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }


        // PAGINATION
        public async Task<Pagination<T>> ToPagination(PaginationParameter paginationParameter)
        {
            var itemCount = await _dbSet.CountAsync();
            var items = await _dbSet.Skip((paginationParameter.Page - 1) * paginationParameter.Limit)
                                    .Take(paginationParameter.Limit)
                                    .AsNoTracking()
                                    .ToListAsync();
            var result = new Pagination<T>(items, itemCount, paginationParameter.Page, paginationParameter.Limit);

            return result;
        }
    }
}
