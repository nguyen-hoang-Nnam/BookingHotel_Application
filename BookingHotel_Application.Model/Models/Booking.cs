using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingHotel_Application.Model.Enum;

namespace BookingHotel_Application.Model.Models
{
    public class Booking
    {
        [Key]
        public int bookingId { get; set; }
        public DateTime bookingDate { get; set; }
        public DateTime checkIn { get; set; }
        public DateTime checkOut { get; set; }
        public decimal totalPrice { get; set; }
        public BookingStatus bookingStatus { get; set; }
        public string userId { get; set; }
        [ForeignKey("userId")]
        public User? User { get; set; }
        public int roomId { get; set; }
        [ForeignKey("roomId")]
        public Room? Room { get; set; }
        public string PaymentLink { get; set; } = string.Empty;
    }
}
