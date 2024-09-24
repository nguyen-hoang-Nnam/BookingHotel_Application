using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel_Application.Model.Models.DTO.Room
{
    public class HotelWithRoomsDTO
    {
        public int hotelId { get; set; }
        public string hotelName { get; set; }
        public string hotelDescription { get; set; }
        public string image { get; set; }
        public string address { get; set; }
        public decimal ratings { get; set; }
        public int countryId { get; set; }
        public string countryName { get; set; }
        public List<RoomDTO> Rooms { get; set; }
    }
}
