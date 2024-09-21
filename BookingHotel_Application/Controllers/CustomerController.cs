using BookingHotel_Application.BLL.Service.IService;
using BookingHotel_Application.Model.Models.DTO.Customer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Route("GetAllCustomer")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var response = await _customerService.GetAllCustomersAsync();
            if (!response.IsSucceed)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("GetCustomerById/{customerid:int}")]
        public async Task<IActionResult> GetCustomerById(int customerid)
        {
            var response = await _customerService.GetCustomerByIdAsync(customerid);
            if (!response.IsSucceed)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("CreateCustomer")]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _customerService.CreateCustomerAsync(customerDto);
            if (!response.IsSucceed)
            {
                return BadRequest(response);
            }

            return CreatedAtAction(nameof(GetCustomerById), new { id = customerDto.customerId }, response);
        }

        [HttpPut]
        [Route("UpdateCustomer/{customerid:int}")]
        public async Task<IActionResult> UpdateCustomer(int customerid, [FromBody] UpdateCustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _customerService.UpdateCustomerAsync(customerid, customerDto);
            if (!response.IsSucceed)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteCustomer/{customerid:int}")]
        public async Task<IActionResult> DeleteCustomer(int customerid)
        {
            var response = await _customerService.DeleteCustomerAsync(customerid);
            if (!response.IsSucceed)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPost]
        [Route("BanCustomer/{customerId:int}")]
        public async Task<IActionResult> BanCustomer(int customerId)
        {
            var response = await _customerService.BanCustomerAsync(customerId);
            if (!response.IsSucceed)
            {
                return NotFound(response);
            }

            return Ok(response);
        }[HttpPost]
        [Route("UnBanCustomer/{customerId:int}")]
        public async Task<IActionResult> UnBanCustomer(int customerId)
        {
            var response = await _customerService.UnBanCustomerAsync(customerId);
            if (!response.IsSucceed)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
