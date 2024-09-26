﻿using BookingHotel_Application.DAL.Repository.IRepository;
using BookingHotel_Application.Model.Commons;
using BookingHotel_Application.Model.Data;
using BookingHotel_Application.Model.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        public virtual Pagination<T> GetFilter(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string includeProperties = "",
            int? pageIndex = null,
            int? pageSize = null,
            string? foreignKey = null,
            object? foreignKeyId = null)
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            var itemCount = query.Count();

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (!string.IsNullOrEmpty(foreignKey) && foreignKeyId != null)
            {
                if (foreignKeyId is Guid guidValue)
                {
                    query = query.Where(e => EF.Property<Guid>(e, foreignKey) == guidValue);
                }
                else if (foreignKeyId is string stringValue)
                {
                    query = query.Where(e => EF.Property<string>(e, foreignKey) == stringValue);
                }
                else
                {
                    throw new ArgumentException("Unsupported foreign key type");
                }
            }

            if (pageIndex.HasValue && pageSize.HasValue)
            {
                int validPageIndex = pageIndex.Value > 0 ? pageIndex.Value - 1 : 0;
                int validPageSize = pageSize.Value > 0 ? pageSize.Value : 10;

                query = query.Skip(validPageIndex * validPageSize).Take(validPageSize);
            }

            var items = query.ToList();
            return new Pagination<T>(items, itemCount, pageIndex ?? 0, pageSize ?? 10);
        }

    }
}
