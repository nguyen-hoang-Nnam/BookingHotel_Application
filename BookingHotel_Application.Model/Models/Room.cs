using BookingHotel_Application.Model.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel_Application.Model.Models
{
    public class Room
    {
        [Key]
        public int roomId { get; set; }
        public string roomName { get; set; }
        public string Image {  get; set; }
        public int guestNumber { get; set; }
        public string roomDes { get; set; }
        public decimal pricePerDay { get; set; }
        public int roomSize { get; set; }
        public RoomStatus roomStatus { get; set; }
        [ForeignKey("hotelId")]
        public Hotel? Hotel { get; set; }
        [ForeignKey("roomTypeId")]
        public RoomType? RoomType { get; set; }

    }
}
