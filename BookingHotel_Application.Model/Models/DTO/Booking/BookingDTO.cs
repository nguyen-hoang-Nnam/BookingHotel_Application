﻿using BookingHotel_Application.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel_Application.Model.Models.DTO.Booking
{
    public class BookingDTO
    {
        public int bookingId { get; set; }
        public DateTime bookingDate { get; set; }
        public DateTime checkIn { get; set; }
        public DateTime checkOut { get; set; }
        public decimal totalPrice { get; set; }
        public BookingStatus bookingStatus { get; set; }
        public string userId { get; set; }
        public string Email { get; set; }
        public string phoneNumber { get; set; }
        public int roomId { get; set; }
        public string roomName { get; set; }
        public decimal pricePerDay { get; set; }
        public int roomSize { get; set; }
    }
}
