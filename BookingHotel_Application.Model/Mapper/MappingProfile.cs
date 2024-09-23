﻿using AutoMapper;
using BookingHotel_Application.Model.Models;
using BookingHotel_Application.Model.Models.DTO.Auth;
using BookingHotel_Application.Model.Models.DTO.Countries;
using BookingHotel_Application.Model.Models.DTO.Customer;
using BookingHotel_Application.Model.Models.DTO.Hotel;
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
            CreateMap<Hotel, HotelDTO>()
            .ForMember(dest => dest.countryName, opt => opt.MapFrom(src => src.Countries.countryName))
            .ForMember(dest => dest.countryId, opt => opt.MapFrom(src => src.Countries.countryId));
            CreateMap<CreateHotelDTO, Hotel>()
            .ForMember(dest => dest.Countries, opt => opt.MapFrom(src => new Countries { countryId = src.countryId }));

            CreateMap<UpdateHotelDTO, Hotel>()
                .ForMember(dest => dest.Countries, opt => opt.MapFrom(src => new Countries { countryId = src.countryId }));

            // Countries
            CreateMap<Countries, CountriesDTO>().ReverseMap();
            CreateMap<Countries, CreateCountriesDTO>() .ReverseMap();
            CreateMap<Countries, UpdateCountriesDTO>().ReverseMap();
        }
    }
}
