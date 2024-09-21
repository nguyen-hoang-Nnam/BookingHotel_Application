using AutoMapper;
using BookingHotel_Application.Model.Models;
using BookingHotel_Application.Model.Models.DTO.Auth;
using BookingHotel_Application.Model.Models.DTO.Customer;
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
        }
    }
}
