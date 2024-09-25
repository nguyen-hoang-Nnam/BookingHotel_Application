using BookingHotel_Application.DAL.Repository.IRepository;
using BookingHotel_Application.Model.Data;
using BookingHotel_Application.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel_Application.DAL.Repository
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        private readonly AppDbContext _appDbContext;

        public CommentRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Comment>> GetAll()
        {
            return await _appDbContext.Comments
                .Include(c => c.Hotel)
                .Include(c => c.User)
                .ToListAsync();
        }

        public async Task<Comment> GetById(int id)
        {
            return await _appDbContext.Comments
                .Include(c => c.Hotel)
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.commentId == id);
        }
    }
}
