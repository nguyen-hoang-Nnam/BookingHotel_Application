using BookingHotel_Application.BLL.Service.IService;
using BookingHotel_Application.Model.Models.DTO.Countries;
using BookingHotel_Application.Model.Models.DTO.RoomType;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomTypeController : ControllerBase
    {
        private readonly IRoomTypeService _roomTypeService;

        public RoomTypeController(IRoomTypeService roomTypeService)
        {
            _roomTypeService = roomTypeService;
        }

        [HttpGet]
        [Route("GetAllRoomType")]
        public async Task<IActionResult> GetAllRoomType()
        {
            var response = await _roomTypeService.GetAllRoomTypeAsync();
            return Ok(response);
        }

        [HttpGet]
        [Route("GetRoomTypeById/{id:int}")]
        public async Task<IActionResult> GetRoomTypeById(int id)
        {
            var response = await _roomTypeService.GetRoomTypeByIdAsync(id);
            if (!response.IsSucceed)
                return NotFound(response);

            return Ok(response);
        }

        [HttpPost]
        [Route("CreateRoomType")]
        public async Task<IActionResult> CreateRoomType([FromBody] CreateRoomTypeDTO createRoomTypeDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _roomTypeService.CreateRoomTypeAsync(createRoomTypeDTO);
            return Ok(response);
        }

        [HttpPut]
        [Route("UpdateRoomType/{id:int}")]
        public async Task<IActionResult> UpdateRoomType(int id, [FromBody] UpdateRoomTypeDTO updateRoomTypeDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _roomTypeService.UpdateRoomTypeAsync(id, updateRoomTypeDTO);
            if (!response.IsSucceed)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteRoomType/{id:int}")]
        public async Task<IActionResult> DeleteRoomType(int id)
        {
            var response = await _roomTypeService.DeleteRoomTypeAsync(id);
            return Ok(response);
        }
    }
}
