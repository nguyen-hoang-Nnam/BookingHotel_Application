using BookingHotel_Application.DAL.Repository.IRepository;
using BookingHotel_Application.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel_Application.DAL.UoW.IUoW
{
    public interface IUnitOfWork
    {
        ICustomerRepository CustomerRepository { get; }
        IUserRepository UserRepository { get; }
        IHotelRepository HotelRepository { get; }
        ICountryRepository CountryRepository { get; }
        IRoomTypeRepository RoomTypeRepository { get; }
        IRoomRepository RoomRepository { get; }
        ICommentRepository CommentRepository { get; }
        IBookingRepository BookingRepository { get; }
        IPaymentRepository PaymentRepository { get; }
        AppDbContext dbContext { get; }
        public Task<int> SaveChangeAsync();
    }
}
