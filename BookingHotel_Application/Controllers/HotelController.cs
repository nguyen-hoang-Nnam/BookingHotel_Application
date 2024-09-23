using BookingHotel_Application.BLL.Service.IService;
using BookingHotel_Application.Model.Models.DTO.Hotel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet]
        [Route("GetAllHotels")]
        public async Task<IActionResult> GetAllHotels()
        {
            var response = await _hotelService.GetAllHotelsAsync();
            return Ok(response);
        }

        [HttpGet]
        [Route("GetHotelById/{id:int}")]
        public async Task<IActionResult> GetHotelById(int id)
        {
            var response = await _hotelService.GetHotelByIdAsync(id);
            if (!response.IsSucceed)
                return NotFound(response);

            return Ok(response);
        }

        [HttpPost]
        [Route("CreateHotel")]
        public async Task<IActionResult> CreateHotel([FromBody] CreateHotelDTO createHotelDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _hotelService.CreateHotelAsync(createHotelDTO);
            return Ok(response);
        }

        [HttpPut]
        [Route("UpdateHotel/{id:int}")]
        public async Task<IActionResult> UpdateHotel(int id, [FromBody] UpdateHotelDTO updateHotelDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _hotelService.UpdateHotelAsync(id, updateHotelDTO);
            if (!response.IsSucceed)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteHotel/{id:int}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var response = await _hotelService.DeleteHotelAsync(id);
            return Ok(response);
        }
    }
}
