using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel_Application.Model.Models
{
    public class Countries
    {
        [Key]
        public int countryId {  get; set; }
        public string countryName { get; set; }
        public ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();
    }
}
