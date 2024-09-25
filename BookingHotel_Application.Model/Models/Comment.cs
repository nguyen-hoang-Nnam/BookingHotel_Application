using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel_Application.Model.Models
{
    public class Comment
    {
        [Key]
        public int commentId { get; set; }
        public DateTime commentDate { get; set; }
        public int Ratings { get; set; }
        public string commentText { get; set; }
        [ForeignKey("hotelId")]
        public Hotel? Hotel { get; set; }
        [ForeignKey("userId")]
        public User? User { get; set; }
    }
}
