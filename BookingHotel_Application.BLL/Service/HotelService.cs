using AutoMapper;
using BookingHotel_Application.BLL.Service.IService;
using BookingHotel_Application.DAL.UoW.IUoW;
using BookingHotel_Application.Model.Models.DTO.Hotel;
using BookingHotel_Application.Model.Models.DTO;
using BookingHotel_Application.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel_Application.BLL.Service
{
    public class HotelService : IHotelService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HotelService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseDTO> GetAllHotelsAsync()
        {
            var hotels = await _unitOfWork.HotelRepository.GetAllAsync();
            var hotelDTOs = _mapper.Map<IEnumerable<HotelDTO>>(hotels);

            return new ResponseDTO
            {
                IsSucceed = true,
                Data = hotelDTOs
            };
        }

        public async Task<ResponseDTO> GetHotelByIdAsync(int hotelid)
        {
            var hotel = await _unitOfWork.HotelRepository.GetByIdAsync(hotelid);
            if (hotel == null)
            {
                return new ResponseDTO
                {
                    IsSucceed = false,
                    Message = "Hotel not found"
                };
            }

            var hotelDTO = _mapper.Map<HotelDTO>(hotel);
            return new ResponseDTO
            {
                IsSucceed = true,
                Data = hotelDTO
            };
        }

        public async Task<ResponseDTO> CreateHotelAsync(CreateHotelDTO createHotelDTO)
        {
            var hotel = _mapper.Map<Hotel>(createHotelDTO);
            await _unitOfWork.HotelRepository.AddAsync(hotel);
            await _unitOfWork.SaveChangeAsync();

            return new ResponseDTO
            {
                IsSucceed = true,
                Message = "Hotel created successfully"
            };
        }

        public async Task<ResponseDTO> UpdateHotelAsync(int hotelid, UpdateHotelDTO updateHotelDTO)
        {
            var hotel = await _unitOfWork.HotelRepository.GetByIdAsync(hotelid);
            if (hotel == null)
            {
                return new ResponseDTO
                {
                    IsSucceed = false,
                    Message = "Hotel not found"
                };
            }

            _mapper.Map(updateHotelDTO, hotel);
            var result = await _unitOfWork.HotelRepository.UpdateAsync(hotel);

            if (!result)
            {
                return new ResponseDTO
                {
                    IsSucceed = false,
                    Message = "Update failed"
                };
            }

            await _unitOfWork.SaveChangeAsync();
            return new ResponseDTO
            {
                IsSucceed = true,
                Message = "Hotel updated successfully"
            };
        }

        public async Task<ResponseDTO> DeleteHotelAsync(int hotelid)
        {
            await _unitOfWork.HotelRepository.DeleteAsync(hotelid);
            await _unitOfWork.SaveChangeAsync();

            return new ResponseDTO
            {
                IsSucceed = true,
                Message = "Hotel deleted successfully"
            };
        }
    }
}
