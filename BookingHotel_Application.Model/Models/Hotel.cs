using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel_Application.Model.Models
{
    public class Hotel
    {
        [Key]
        public int hotelId { get; set; }
        public string hotelName { get; set; }
        public string hotelDescription { get; set; }
        public string Image {  get; set; }
        public string Address { get; set; }
        public int Ratings { get; set; }
        [ForeignKey("countryId")]
        public Countries? Countries { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
