using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel_Application.Model.Models.DTO.Comment
{
    public class CreateCommentDTO
    {
        public int Ratings { get; set; }
        public string commentText { get; set; }
        public int hotelId { get; set; }
        public string userId { get; set; }
    }
}
