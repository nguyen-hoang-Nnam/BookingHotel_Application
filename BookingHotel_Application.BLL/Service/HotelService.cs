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
using BookingHotel_Application.Model.Helper;

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
            var hotels = await _unitOfWork.HotelRepository.GetAll();
            var hotelDTOs = _mapper.Map<IEnumerable<HotelDTO>>(hotels);

            return new ResponseDTO
            {
                IsSucceed = true,
                Data = hotelDTOs
            };
        }

        public async Task<ResponseDTO> GetHotelByIdAsync(int hotelid)
        {
            var hotel = await _unitOfWork.HotelRepository.GetById(hotelid);
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
            var country = await _unitOfWork.CountryRepository.GetByIdAsync(createHotelDTO.countryId);
            if (country == null)
            {
                return new ResponseDTO
                {
                    IsSucceed = false,
                    Message = "Country not found."
                };
            }
            var hotel = _mapper.Map<Hotel>(createHotelDTO);
            hotel.Countries = country;
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
            var country = await _unitOfWork.CountryRepository.GetByIdAsync(updateHotelDTO.countryId);
            if (country == null)
            {
                return new ResponseDTO
                {
                    IsSucceed = false,
                    Message = "Country not found."
                };
            }

            _mapper.Map(updateHotelDTO, hotel);
            hotel.Countries = country;
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
        public async Task<ResponseDTO> GetHotelsByCountryIdAsync(int countryId)
        {
            var hotels = await _unitOfWork.HotelRepository.GetHotelsByCountryIdAsync(countryId);

            if (!hotels.Any())
            {
                return new ResponseDTO
                {
                    IsSucceed = false,
                    Message = "No hotels found for the given country."
                };
            }

            var hotelDTOs = _mapper.Map<IEnumerable<HotelDTO>>(hotels);

            return new ResponseDTO
            {
                IsSucceed = true,
                Data = hotelDTOs
            };
        }
        public async Task<ResponseDTO> GetHotelDetailsAsync(int hotelId)
        {
            var hotel = await _unitOfWork.HotelRepository.GetHotelWithRoomsAndCommentsAsync(hotelId);

            if (hotel == null)
            {
                return new ResponseDTO
                {
                    IsSucceed = false,
                    Message = "Hotel not found",
                    Data = null
                };
            }

            var hotelWithDetailsDTO = _mapper.Map<HotelWithDetailDTO>(hotel);

            return new ResponseDTO
            {
                IsSucceed = true,
                Message = "Hotel details retrieved successfully",
                Data = hotelWithDetailsDTO
            };
        }

        public async Task<ResponseDTO> GetPaginatedHotelsAsync(PaginationParameter paginationParameter)
        {
            var paginatedHotels = _unitOfWork.HotelRepository.GetFilter(
                pageIndex: paginationParameter.Page,
                pageSize: paginationParameter.Limit,
                orderBy: query => query.OrderBy(h => h.hotelId)
            );

            if (paginatedHotels == null || !paginatedHotels.Items.Any())
            {
                return new ResponseDTO
                {
                    IsSucceed = false,
                    Message = "No hotels found",
                    Data = null
                };
            }

            // Map hotel entities to DTOs
            var paginatedHotelDTOs = _mapper.Map<List<PaginationHotelDTO>>(paginatedHotels.Items);

            var paginationMetadata = new
            {
                paginatedHotels.PageIndex,
                paginatedHotels.PageSize,
                paginatedHotels.TotalItemsCount,
                paginatedHotels.TotalPagesCount,
                paginatedHotels.Next,
                paginatedHotels.Previous
            };

            return new ResponseDTO
            {
                IsSucceed = true,
                Message = "Hotels retrieved successfully",
                Data = new { hotels = paginatedHotelDTOs, pagination = paginationMetadata }
            };
        }
    }
}
