using AutoMapper;
using BookingHotel_Application.BLL.Service.IService;
using BookingHotel_Application.DAL.Repository.IRepository;
using BookingHotel_Application.Model.Models.DTO.Booking;
using BookingHotel_Application.Model.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingHotel_Application.DAL.UoW.IUoW;
using BookingHotel_Application.DAL.Repository;
using BookingHotel_Application.Model.Models.DTO.Comment;
using BookingHotel_Application.Model.Models;

namespace BookingHotel_Application.BLL.Service
{
    public class BookingService : IBookingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        public BookingService(IMapper mapper, IUnitOfWork unitOfWork, IPaymentService paymentService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _paymentService = paymentService;
        }

        public async Task<ResponseDTO> GetAllBookingsAsync()
        {
            var bookings = await _unitOfWork.BookingRepository.GetAll();
            var data = _mapper.Map<IEnumerable<BookingDTO>>(bookings);

            return new ResponseDTO
            {
                IsSucceed = true,
                Message = "Bookings retrieved successfully",
                Data = data
            };
        }
        public async Task<ResponseDTO> GetBookingByIdAsync(int id)
        {
            var booking = await _unitOfWork.BookingRepository.GetById(id);
            if (booking == null)
            {
                return new ResponseDTO
                {
                    IsSucceed = false,
                    Message = "Booking not found"
                };
            }

            var bookingDTO = _mapper.Map<BookingDTO>(booking);
            return new ResponseDTO
            {
                IsSucceed = true,
                Message = "Booking retrieved successfully", 
                Data = bookingDTO
            };
        }

        public async Task<ResponseDTO> CreateBookingAsync(CreateBookingDTO createBookingDTO)
        {
            var room = await _unitOfWork.RoomRepository.GetByIdAsync(createBookingDTO.roomId);
            var user = await _unitOfWork.UserRepository.GetByIdAsync(createBookingDTO.userId);

            if (room == null || user == null)
            {
                return new ResponseDTO { IsSucceed = false, Message = "Room or User not found" };
            }

            var numberOfDays = (createBookingDTO.checkOut - createBookingDTO.checkIn).TotalDays;
            var totalPrice = room.pricePerDay * (decimal)numberOfDays;

            var booking = _mapper.Map<Booking>(createBookingDTO);
            booking.bookingDate = DateTime.UtcNow;
            booking.bookingStatus = Model.Enum.BookingStatus.Pending;
            booking.totalPrice = totalPrice;
            booking.Room = room;
            booking.User = user;

            // Add booking to database
            await _unitOfWork.BookingRepository.AddAsync(booking);
            await _unitOfWork.SaveChangeAsync();

            booking.PaymentLink = string.Empty;

            // Create a payment link
            ResponseDTO paymentResponse;
            try
            {
                paymentResponse = await _paymentService.CreatePaymentLink(booking, totalPrice);

                if (!paymentResponse.IsSucceed)
                {
                    return new ResponseDTO { IsSucceed = false, Message = paymentResponse.Message };
                }

                // Handle paymentResponse.Data correctly
                if (paymentResponse.Data is not null)
                {
                    // Extract the paymentUrl from the anonymous object returned by CreatePaymentLink
                    var paymentData = paymentResponse.Data as dynamic;
                    booking.PaymentLink = paymentData?.paymentUrl ?? string.Empty;  // Correctly assign paymentUrl
                }

                // Update booking with payment link
                _unitOfWork.BookingRepository.Update(booking);
                await _unitOfWork.SaveChangeAsync();
            }
            catch (Exception ex)
            {
                return new ResponseDTO { IsSucceed = false, Message = "Failed to create payment link: " + ex.Message };
            }

            // Return a custom object with the necessary booking and payment information
            var bookingResponse = new
            {
                booking.bookingId,
                booking.bookingDate,
                booking.checkIn,
                booking.checkOut,
                booking.totalPrice,
                booking.PaymentLink
            };

            return new ResponseDTO
            {
                IsSucceed = true,
                Message = "Booking created successfully",
                Data = bookingResponse  // Return booking and payment details as part of the response
            };
        }

        public async Task<ResponseDTO> UpdateBookingAsync(UpdateBookingDTO updateBookingDTO)
        {
            var booking = await _unitOfWork.BookingRepository.GetByIdAsync(updateBookingDTO.bookingId);
            if (booking == null)
            {
                return new ResponseDTO { IsSucceed = false, Message = "Booking not found" };
            }

            _mapper.Map(updateBookingDTO, booking);
            await _unitOfWork.SaveChangeAsync();

            return new ResponseDTO { IsSucceed = true, Message = "Booking updated successfully" };
        }

        public async Task<ResponseDTO> DeleteBookingAsync(int bookingId)
        {

            await _unitOfWork.BookingRepository.DeleteAsync(bookingId);
            await _unitOfWork.SaveChangeAsync();

            return new ResponseDTO { IsSucceed = true, Message = "Booking deleted successfully" };
        }

        public async Task<ResponseDTO> GetBookingsByUserId(string userId)
        {
            var response = new ResponseDTO();

            var bookings = await _unitOfWork.BookingRepository.GetBookingsByUserIdAsync(userId);

            if (!bookings.Any())
            {
                response.Message = "No bookings found for the given user.";
                return response;
            }

            var bookingDTOs = _mapper.Map<IEnumerable<BookingDTO>>(bookings);

            response.IsSucceed = true;
            response.Data = bookingDTOs;

            return response;
        }
    }
}
