using BookingHotel_Application.BLL.Service.IService;
using BookingHotel_Application.Model.Models.DTO.Countries;
using BookingHotel_Application.Model.Models.DTO.Hotel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        [Route("GetAllCountries")]
        public async Task<IActionResult> GetAllCountries()
        {
            var response = await _countryService.GetAllCountriesAsync();
            return Ok(response);
        }

        [HttpGet]
        [Route("GetCountriesById/{id:int}")]
        public async Task<IActionResult> GetCountriesById(int id)
        {
            var response = await _countryService.GetCountriesByIdAsync(id);
            if (!response.IsSucceed)
                return NotFound(response);

            return Ok(response);
        }

        [HttpPost]
        [Route("CreateCountries")]
        public async Task<IActionResult> CreateCountries([FromBody] CreateCountriesDTO createCountriesDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _countryService.CreateCountriesAsync(createCountriesDTO);
            return Ok(response);
        }

        [HttpPut]
        [Route("UpdateCountries/{id:int}")]
        public async Task<IActionResult> UpdateCountries(int id, [FromBody] UpdateCountriesDTO updateCountriesDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _countryService.UpdateCountriesAsync(id, updateCountriesDTO);
            if (!response.IsSucceed)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteCountries/{id:int}")]
        public async Task<IActionResult> DeleteCountries(int id)
        {
            var response = await _countryService.DeleteCountriesAsync(id);
            return Ok(response);
        }
    }
}
