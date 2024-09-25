using BookingHotel_Application.Model.Models.DTO.Comment;
using BookingHotel_Application.Model.Models.DTO.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel_Application.Model.Models.DTO.Hotel
{
    public class HotelWithDetailDTO
    {
        public int hotelId { get; set; }
        public string hotelName { get; set; }
        public string hotelDescription { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public int Ratings { get; set; }
        public int countryId { get; set; }
        public string countryName { get; set; }

        public IEnumerable<RoomDTO> Rooms { get; set; }
        public IEnumerable<CommentDTO> Comments { get; set; }
    }
}
