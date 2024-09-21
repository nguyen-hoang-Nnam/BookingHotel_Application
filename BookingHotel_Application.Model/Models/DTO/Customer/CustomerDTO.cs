using BookingHotel_Application.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel_Application.Model.Models.DTO.Customer
{
    public class CustomerDTO
    {
        public int customerId { get; set; }
        public string userId { get; set; }
        public string userName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string Address { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public UserStatus status { get; set; }
    }
}
