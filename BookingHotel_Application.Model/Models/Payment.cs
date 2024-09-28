using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel_Application.Model.Models
{
    public class Payment
    {
        [Key]
        public int paymentId { get; set; }
        public string paymentStauts { get; set; }
        public string transactionId { get; set; }
        public decimal amountPaid { get; set; }
        public int bookingId { get; set; }
        [ForeignKey("bookingId")]
        public Booking? Booking { get; set; }
    }
}
