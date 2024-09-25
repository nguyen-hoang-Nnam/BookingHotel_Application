using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel_Application.Model.Models.DTO.Comment
{
    public class CommentDTO
    {
        public int commentId { get; set; }
        public int Ratings { get; set; }
        public string commentText { get; set; }
        public DateTime commentDate { get; set; }
        public int hotelId { get; set; }
        public string hotelName { get; set; }
        public string userId { get; set; }
        public string userName { get; set; }
    }
}
