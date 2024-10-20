using BookingHotel_Application.Model.Models;
using BookingHotel_Application.Model.Models.DTO;
using BookingHotel_Application.Model.Models.DTO.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel_Application.BLL.Service.IService
{
    public interface IPaymentService
    {
        Task<ResponseDTO> CreatePaymentLink(Booking booking, decimal totalPrice);
         Task HandlePaymentSuccess(string paymentId);
        Task<ResponseDTO> HandlePaymentByTransactionId(string transactionId);
        Task<ResponseDTO> GetPendingPayments();
        Task<ResponseDTO> GetSuccessPayments();
    }
}
