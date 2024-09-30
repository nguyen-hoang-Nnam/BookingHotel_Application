using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel_Application.Model.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int customerId { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? Address { get; set; }
        public string userId { get; set; }
        [ForeignKey("userId")]
        public User? User { get; set; }
    }
}
