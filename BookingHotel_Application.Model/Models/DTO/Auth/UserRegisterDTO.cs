using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel_Application.Model.Models.DTO.Auth
{
    public class UserRegisterDTO
    {
        public string userName { get; set; }
        public string Email { get; set; }
        public string phoneNumber { get; set; }
        public string Password { get; set; }
    }
}
