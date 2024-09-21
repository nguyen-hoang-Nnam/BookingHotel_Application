using BookingHotel_Application.BLL.Service.IService;
using BookingHotel_Application.Model.Models.DTO.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterDTO userRegisterDTO)
        {
            var result = await _authService.RegisterUserAsync(userRegisterDTO);
            if (!result.IsSucceed)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDTO userLoginDTO)
        {
            var result = await _authService.LoginUserAsync(userLoginDTO);
            if (!result.IsSucceed)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
