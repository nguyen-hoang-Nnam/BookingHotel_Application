using BookingHotel_Application.BLL.Service;
using BookingHotel_Application.BLL.Service.IService;
using BookingHotel_Application.Model.Models.DTO.Booking;
using BookingHotel_Application.Model.Models.DTO.Comment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        // GetAllBookings
        [HttpGet("GetAllBookings")]
        public async Task<IActionResult> GetAllBookings()
        {
            var result = await _bookingService.GetAllBookingsAsync();
            return Ok(result);
        }

        // GetBookingById
        [HttpGet]
        [Route("GetBookingById/{id:int}")]
        public async Task<IActionResult> GetBookingById(int id)
        {
            var result = await _bookingService.GetBookingByIdAsync(id);
            if (!result.IsSucceed) return NotFound(result);
            return Ok(result);
        }

        // CreateBooking
        [HttpPost("CreateBooking")]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingDTO createBookingDTO)
        {
            var result = await _bookingService.CreateBookingAsync(createBookingDTO);
            if (result.IsSucceed)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        // UpdateBooking
        [HttpPut]
        [Route("UpdateBooking/{id:int}")]
        public async Task<IActionResult> UpdateBooking([FromBody] UpdateBookingDTO updateBookingDTO)
        {
            var result = await _bookingService.UpdateBookingAsync(updateBookingDTO);
            if (result.IsSucceed)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        // DeleteBooking
        [HttpDelete]
        [Route("DeleteBooking/{id:int}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var result = await _bookingService.DeleteBookingAsync(id);
            if (result.IsSucceed)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
