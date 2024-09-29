using BookingHotel_Application.BLL.Service.IService;
using BookingHotel_Application.DAL.UoW.IUoW;
using BookingHotel_Application.Model.Enum;
using BookingHotel_Application.Model.Models;
using BookingHotel_Application.Model.Models.DTO;
using BookingHotel_Application.Model.Models.DTO.Payment;
using Net.payOS;
using Net.payOS.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel_Application.BLL.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly PayOS _payOS;
        private readonly IUnitOfWork _unitOfWork;

        public PaymentService(PayOS payOS, IUnitOfWork unitOfWork)
        {
            _payOS = payOS;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseDTO> CreatePaymentLink(Booking booking, decimal totalPrice)
        {
            try
            {
                int orderCode = int.Parse(DateTimeOffset.Now.ToString("ffffff"));

                // Create the item for payment (room name and total price for the number of days)
                ItemData item = new ItemData(booking.Room.roomName, 1, (int)totalPrice);
                List<ItemData> items = new List<ItemData> { item };

                // Create payment data
                PaymentData paymentData = new PaymentData(orderCode, (int)totalPrice, "Payment for booking", items, "https://www.facebook.com/FPTU.HCM", "https://fap.fpt.edu.vn/");

                // Call PayOS to generate the payment link
                CreatePaymentResult paymentResult = await _payOS.createPaymentLink(paymentData);
                if (paymentResult == null)
                {
                    throw new Exception("Payment result is null.");
                }

                // Store initial payment details in the database
                var payment = new Payment
                {
                    paymentStauts = "Pending",
                    transactionId = paymentResult.paymentLinkId,
                    amountPaid = totalPrice,
                    bookingId = booking.bookingId
                };

                await _unitOfWork.PaymentRepository.AddAsync(payment);
                await _unitOfWork.SaveChangeAsync();

                // Create a DTO to return all necessary booking and payment information
                var paymentBookingResponse = new
                {
                    bookingId = booking.bookingId,
                    roomName = booking.Room.roomName,
                    checkIn = booking.checkIn,
                    checkOut = booking.checkOut,
                    totalPrice = totalPrice,
                    paymentUrl = paymentResult.checkoutUrl  // This is the actual payment link
                };


                return new ResponseDTO
                {
                    IsSucceed = true,
                    Message = "Booking created and payment link generated successfully.",
                    Data = paymentBookingResponse
                };
            }
            catch (Exception ex)
            {
                // Handle exceptions and return a failure ResponseDTO
                return new ResponseDTO
                {
                    IsSucceed = false,
                    Message = "Failed to create payment link: " + ex.Message
                };
            }
        }


        public async Task HandlePaymentSuccess(string paymentId)
        {
            // Logic to handle the successful payment (e.g., updating booking status)
            Console.WriteLine($"Payment successful for paymentId: {paymentId}");

            // You might want to update the booking status in the database here
            var payment = await _unitOfWork.PaymentRepository.GetByTransactionId(paymentId);
            if (payment != null)
            {
                // Fetch the booking using the bookingId from the payment
                var booking = await _unitOfWork.BookingRepository.GetByIdAsync(payment.bookingId);
                if (booking != null)
                {
                    booking.bookingStatus = BookingStatus.Booked;
                    _unitOfWork.BookingRepository.Update(booking);
                    await _unitOfWork.SaveChangeAsync();
                }
                var paymentStatus = await _unitOfWork.PaymentRepository.GetByIdAsync(paymentId);
                if (paymentStatus != null)
                {
                    paymentStatus.paymentStauts = "Success";
                    _unitOfWork.PaymentRepository.Update(paymentStatus);
                    await _unitOfWork.SaveChangeAsync();
                }
            }
        }

        public async Task<ResponseDTO> HandlePaymentByTransactionId(string transactionId)
        {
            // Log the transactionId for debugging
            Console.WriteLine($"Handling payment with transactionId: {transactionId}");

            // Fetch payment by transactionId
            var payment = await _unitOfWork.PaymentRepository.GetByTransactionId(transactionId);

            if (payment == null)
            {
                // Return failure response if payment is not found
                return new ResponseDTO
                {
                    IsSucceed = false,
                    Message = "Payment not found for the given transactionId."
                };
            }

            // Fetch the associated booking using bookingId from the payment entity
            var booking = await _unitOfWork.BookingRepository.GetByIdAsync(payment.bookingId);

            if (booking == null)
            {
                // Return failure response if booking is not found
                return new ResponseDTO
                {
                    IsSucceed = false,
                    Message = "Booking not found for the given payment."
                };
            }

            // Update the booking status to Booked (or any other relevant status)
            booking.bookingStatus = BookingStatus.Booked;
            _unitOfWork.BookingRepository.Update(booking); // Update the booking entity

            // Update the payment status to Success
            payment.paymentStauts = "Success";
            _unitOfWork.PaymentRepository.Update(payment); // Update the payment entity

            // Save the changes for both booking and payment
            await _unitOfWork.SaveChangeAsync();

            // Return a success response with updated booking and payment details
            var response = new
            {
                bookingId = booking.bookingId,
                bookingStatus = booking.bookingStatus.ToString(),
                paymentStatus = payment.paymentStauts
            };

            return new ResponseDTO
            {
                IsSucceed = true,
                Message = "Payment handled and booking status updated successfully.",
                Data = response
            };
        }

    }
}
