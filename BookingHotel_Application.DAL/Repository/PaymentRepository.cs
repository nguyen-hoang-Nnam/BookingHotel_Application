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
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        private readonly AppDbContext _appDbContext;

        public PaymentRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Payment> GetByTransactionId(string transactionId)
        {
            return await _appDbContext.Payments.FirstOrDefaultAsync(p => p.transactionId == transactionId);
        }

        public void Update(Payment payment)
        {
            _appDbContext.Payments.Update(payment);
        }

        public IQueryable<Payment> GetPendingPayments()
        {
            return _appDbContext.Payments
                .Include(p => p.Booking)
                .ThenInclude(b => b.User)
                .Include(p => p.Booking.Room)
                .Where(p => p.paymentStauts == "Pending");
        }

        public IQueryable<Payment> GetSuccessPayments()
        {
            return _appDbContext.Payments
                .Include(p => p.Booking)
                .ThenInclude(b => b.User)
                .Include(p => p.Booking.Room)
                .Where(p => p.paymentStauts == "Success");
        }
    }
}
