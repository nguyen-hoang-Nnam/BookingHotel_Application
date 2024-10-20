using BookingHotel_Application.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel_Application.DAL.Repository.IRepository
{
    public interface IPaymentRepository : IGenericRepository<Payment>
    {
        Task<Payment> GetByTransactionId(string transactionId);
        void Update(Payment payment);
        IQueryable<Payment> GetPendingPayments();
        IQueryable<Payment> GetSuccessPayments();
    }
}
