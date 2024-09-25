using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel_Application.Model.Models.DTO.Comment
{
    public class UpdateCommentDTO
    {
        public int commentId { get; set; }
        public int Ratings { get; set; }
        public string commentText { get; set; }
    }
}
