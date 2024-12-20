﻿using AutoMapper;
using BookingHotel_Application.Model.Enum;
using BookingHotel_Application.Model.Models;
using BookingHotel_Application.Model.Models.DTO.Auth;
using BookingHotel_Application.Model.Models.DTO.Booking;
using BookingHotel_Application.Model.Models.DTO.Comment;
using BookingHotel_Application.Model.Models.DTO.Countries;
using BookingHotel_Application.Model.Models.DTO.Customer;
using BookingHotel_Application.Model.Models.DTO.Hotel;
using BookingHotel_Application.Model.Models.DTO.Payment;
using BookingHotel_Application.Model.Models.DTO.Room;
using BookingHotel_Application.Model.Models.DTO.RoomType;
using BookingHotel_Application.Model.Models.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel_Application.Model.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<CreateUserDTO, User>().ReverseMap();
            CreateMap<UserLoginDTO, User>().ReverseMap();
            CreateMap<UserRegisterDTO, User>().ReverseMap();
            CreateMap<User, UserLoginDTO>().ReverseMap();
            CreateMap<User, UserRegisterDTO>().ReverseMap();
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Customer, UpdateCustomerDTO>().ReverseMap();
            CreateMap<Customer, CustomerDTO>()
            .ForMember(dest => dest.userId, opt => opt.MapFrom(src => src.User.userId))
            .ForMember(dest => dest.userName, opt => opt.MapFrom(src => src.User.userName))
            .ForMember(dest => dest.email, opt => opt.MapFrom(src => src.User.Email))
            .ForMember(dest => dest.phoneNumber, opt => opt.MapFrom(src => src.User.phoneNumber))
            .ForMember(dest => dest.status, opt => opt.MapFrom(src => src.User.Status));

            //Hotel
            CreateMap<Hotel, HotelDTO>().ReverseMap();
            CreateMap<Hotel, UpdateHotelDTO>() .ReverseMap();
            CreateMap<Hotel, CreateHotelDTO>().ReverseMap();
            CreateMap<Hotel, PaginationHotelDTO>() .ReverseMap();
            CreateMap<Hotel, HotelDTO>()
            .ForMember(dest => dest.countryName, opt => opt.MapFrom(src => src.Countries.countryName))
            .ForMember(dest => dest.countryId, opt => opt.MapFrom(src => src.Countries.countryId));
            CreateMap<CreateHotelDTO, Hotel>()
            .ForMember(dest => dest.Countries, opt => opt.MapFrom(src => new Countries { countryId = src.countryId }));

            CreateMap<UpdateHotelDTO, Hotel>()
                .ForMember(dest => dest.Countries, opt => opt.MapFrom(src => new Countries { countryId = src.countryId }));

            CreateMap<Hotel, HotelWithDetailDTO>()
            .ForMember(dest => dest.Rooms, opt => opt.MapFrom(src => src.Rooms))
            .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments))
            .ForMember(dest => dest.countryId, opt => opt.MapFrom(src => src.Countries.countryId))
            .ForMember(dest => dest.countryName, opt => opt.MapFrom(src => src.Countries.countryName));

            // Countries
            CreateMap<Countries, CountriesDTO>().ReverseMap();
            CreateMap<Countries, CreateCountriesDTO>() .ReverseMap();
            CreateMap<Countries, UpdateCountriesDTO>().ReverseMap();

            // Room Type
            CreateMap<RoomType, RoomTypeDTO>() .ReverseMap();
            CreateMap<RoomType, CreateRoomTypeDTO>() .ReverseMap();
            CreateMap<RoomType, UpdateRoomTypeDTO>() .ReverseMap();

            // Room
            CreateMap<Room, RoomDTO>().ReverseMap();
            CreateMap<Room, CreateRoomDTO>() .ReverseMap();
            CreateMap<Room, UpdateRoomDTO>() .ReverseMap();
            CreateMap<Room, RoomDTO>()
            .ForMember(dest => dest.roomName, opt => opt.MapFrom(src => src.roomName))
            .ForMember(dest => dest.roomTypeId, opt => opt.MapFrom(src => src.RoomType.roomTypeId))
            .ForMember(dest => dest.hotelId, opt => opt.MapFrom(src => src.Hotel.hotelId))
            .ForMember(dest => dest.hotelName, opt => opt.MapFrom(src => src.Hotel.hotelName))
            .ForMember(dest => dest.roomTypeName, opt => opt.MapFrom(src => src.RoomType.roomTypeName));

            CreateMap<Hotel, HotelWithRoomsDTO>()
            .ForMember(dest => dest.countryName, opt => opt.MapFrom(src => src.Countries.countryName))
            .ForMember(dest => dest.countryId, opt => opt.MapFrom(src => src.Countries.countryId));

            CreateMap<CreateRoomDTO, Room>()
                .ForMember(dest => dest.RoomType, opt => opt.MapFrom(src => new RoomType { roomTypeId = src.roomTypeId }))
                .ForMember(dest => dest.Hotel, opt => opt.MapFrom(src => new Hotel { hotelId = src.hotelId }));
            CreateMap<UpdateRoomDTO, Room>()
                .ForMember(dest => dest.RoomType, opt => opt.MapFrom(src => new RoomType { roomTypeId = src.roomTypeId }))
                .ForMember(dest => dest.Hotel, opt => opt.MapFrom(src => new Hotel { hotelId = src.hotelId }));

            //Comment
            CreateMap<Comment, CommentDTO>()
                .ForMember(dest => dest.hotelId, opt => opt.MapFrom(src => src.Hotel.hotelId))
                .ForMember(dest => dest.hotelName, opt => opt.MapFrom(src => src.Hotel.hotelName))
                .ForMember(dest => dest.userId, opt => opt.MapFrom(src => src.User.userId))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email));

            CreateMap<CreateCommentDTO, Comment>().ReverseMap();

            CreateMap<UpdateCommentDTO, Comment>()
                .ForMember(dest => dest.commentId, opt => opt.Ignore())
                .ForMember(dest => dest.commentText, opt => opt.MapFrom(src => src.commentText));

            // Booking
            CreateMap<Booking, BookingDTO>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.phoneNumber, opt => opt.MapFrom(src => src.User.phoneNumber))
                .ForMember(dest => dest.roomName, opt => opt.MapFrom(src => src.Room.roomName))
                .ForMember(dest => dest.pricePerDay, opt => opt.MapFrom(src => src.Room.pricePerDay))
                .ForMember(dest => dest.roomSize, opt => opt.MapFrom(src => src.Room.roomSize));
            CreateMap<Booking, CreateBookingDTO>().ReverseMap();
            /*.ForMember(dest => dest.PaymentLink, opt => opt.MapFrom(src => src.PaymentLink));*/

            CreateMap<CreateBookingDTO, Booking>()
            .ForMember(dest => dest.bookingId, opt => opt.Ignore()) // Ignore bookingId
            .ForMember(dest => dest.bookingDate, opt => opt.MapFrom(src => DateTime.UtcNow)) // Set bookingDate from current time
            .ForMember(dest => dest.totalPrice, opt => opt.Ignore()) // Ignore totalPrice and calculate it in service
            .ForMember(dest => dest.bookingStatus, opt => opt.MapFrom(src => BookingStatus.Booked)) // Set default status
            .ReverseMap();
            CreateMap<Booking, UpdateBookingDTO>().ReverseMap();

            // Payment
            CreateMap<Payment, PaymentDTO>().ReverseMap();
            CreateMap<Payment, PaymentDTO>()
            .ForMember(dest => dest.bookingId, opt => opt.MapFrom(src => src.Booking.bookingId))
            .ForMember(dest => dest.bookingDate, opt => opt.MapFrom(src => src.Booking.bookingDate))
            .ForMember(dest => dest.checkIn, opt => opt.MapFrom(src => src.Booking.checkIn))
            .ForMember(dest => dest.checkOut, opt => opt.MapFrom(src => src.Booking.checkOut))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Booking.User.Email))
            .ForMember(dest => dest.phoneNumber, opt => opt.MapFrom(src => src.Booking.User.phoneNumber))
            .ForMember(dest => dest.roomName, opt => opt.MapFrom(src => src.Booking.Room.roomName))
            .ForMember(dest => dest.pricePerDay, opt => opt.MapFrom(src => src.Booking.Room.pricePerDay))
            .ForMember(dest => dest.roomSize, opt => opt.MapFrom(src => src.Booking.Room.roomSize))
            .ReverseMap();


        }
    }
}
