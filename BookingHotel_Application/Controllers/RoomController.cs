using BookingHotel_Application.BLL.Service.IService;
using BookingHotel_Application.Model.Models.DTO.Hotel;
using BookingHotel_Application.Model.Models.DTO.Room;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        [Route("GetAllRooms")]
        public async Task<IActionResult> GetAllRooms()
        {
            var response = await _roomService.GetAllRoomAsync();
            return Ok(response);
        }

        [HttpGet]
        [Route("GetRoomById/{id:int}")]
        public async Task<IActionResult> GetRoomById(int id)
        {
            var response = await _roomService.GetRoomByIdAsync(id);
            if (!response.IsSucceed)
                return NotFound(response);

            return Ok(response);
        }

        [HttpPost]
        [Route("CreateRoom")]
        public async Task<IActionResult> CreateRoom([FromBody] CreateRoomDTO createRoomDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _roomService.CreateRoomAsync(createRoomDTO);
            return Ok(response);
        }

        [HttpPut]
        [Route("UpdateRoom/{id:int}")]
        public async Task<IActionResult> UpdateRoom(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _roomService.UpdateRoomAsync(id);
            if (!response.IsSucceed)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteRoom/{id:int}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var response = await _roomService.DeleteRoomAsync(id);
            return Ok(response);
        }

        [HttpGet("GetRoomByRoomTypeId/{roomTypeId}")]
        public async Task<IActionResult> GetRoomByRoomTypeId(int roomTypeId)
        {
            var result = await _roomService.GetRoomsByRoomTypeIdAsync(roomTypeId);
            if (!result.IsSucceed)
            {
                return NotFound(result.Message);
            }
            return Ok(result.Data);
        }

        [HttpGet("GetRoomByHotelTypeId/{hotelId}")]
        public async Task<IActionResult> GetRoomByHotelTypeId(int hotelId)
        {
            var result = await _roomService.GetRoomsByHotelIdAsync(hotelId);
            if (!result.IsSucceed)
            {
                return NotFound(result.Message);
            }
            return Ok(result.Data);
        }
    }
}
