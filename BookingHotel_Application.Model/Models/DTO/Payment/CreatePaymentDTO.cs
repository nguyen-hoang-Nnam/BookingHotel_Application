using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel_Application.Model.Models.DTO.Payment
{
    public class CreatePaymentDTO
    {
        public int bookingId { get; set; }
        public string roomName { get; set; }
    }
}
