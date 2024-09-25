using BookingHotel_Application.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel_Application.DAL.Repository.IRepository
{
    public interface ICommentRepository: IGenericRepository<Comment>
    {
        Task<IEnumerable<Comment>> GetAll();
        Task<Comment> GetById(int id);
    }
}
