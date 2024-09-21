using BookingHotel_Application.Model.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel_Application.Model.Models
{
    public class User
    {
        [Key]
        public string userId {  get; set; }
        public string userName { get; set; }
        public string Email { get; set; }
        public string passwordHash { get; set; }
        public string phoneNumber { get; set; }
        public string refreshToken { get; set; } = string.Empty;
        public UserRole Role { get; set; }
        public UserStatus Status { get; set; }
    }
}
