using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel_Application.Model.Models.DTO.Hotel
{
    public class UpdateHotelDTO
    {
        public string hotelName { get; set; }
        public string hotelDescription { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public int Ratings { get; set; }
        public int countryId { get; set; }
    }
}
