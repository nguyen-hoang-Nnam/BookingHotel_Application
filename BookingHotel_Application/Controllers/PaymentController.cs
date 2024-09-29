using BookingHotel_Application.BLL.Service.IService;
using BookingHotel_Application.Model.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("CreatePayment")]
        public async Task<IActionResult> CreatePayment([FromBody] Booking booking)
        {
            if (booking == null)
            {
                return BadRequest("Booking is null");
            }

            decimal totalPrice = CalculateTotalPrice(booking); // Implement this method

            var paymentLink = await _paymentService.CreatePaymentLink(booking, totalPrice);

            return Ok(new { PaymentLink = paymentLink });
        }

        [HttpGet("HandlePaymentSuccess/{paymentId}")]
        public async Task<IActionResult> HandlePaymentSuccess(string paymentId)
        {
            await _paymentService.HandlePaymentSuccess(paymentId);
            return Ok("Payment processed successfully.");
        }
        
        [HttpGet("ConfirmPayment/{transactionId}")]
        public async Task<IActionResult> ConfirmPayment(string transactionId)
        {
            await _paymentService.HandlePaymentByTransactionId(transactionId);
            return Ok("Payment processed successfully.");
        }

        private decimal CalculateTotalPrice(Booking booking)
        {
            return booking.totalPrice;
        }
    }
}
