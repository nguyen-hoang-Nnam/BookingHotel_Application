using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel_Application.Model.Models
{
    public class RoomType
    {
        [Key]
        public int roomTypeId {  get; set; }
        public string roomTypeName { get; set; }
    }
}
