using BookingHotel_Application.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel_Application.Model.Models.DTO.Room
{
    public class RoomDTO
    {
        public int roomId { get; set; }
        public string roomName { get; set; }
        public string Image { get; set; }
        public int guestNumber { get; set; }
        public string roomDes { get; set; }
        public decimal pricePerDay { get; set; }
        public int roomSize { get; set; }
        public RoomStatus roomStatus { get; set; }
        public int hotelId { get; set; }
        public int roomTypeId { get; set; }
    }
}
