using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel_Application.Model.Models.DTO.Payment
{
    public class PaymentDTO
    {
        public int paymentId { get; set; }
        public string paymentStauts { get; set; }
        public string transactionId { get; set; }
        public decimal amountPaid { get; set; }
        public int bookingId { get; set; }
        public DateTime bookingDate { get; set; }
        public DateTime checkIn { get; set; }
        public DateTime checkOut { get; set; }
        public string Email { get; set; }
        public string phoneNumber { get; set; }
        public string roomName { get; set; }
        public decimal pricePerDay { get; set; }
        public int roomSize { get; set; }
    }
}
