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
using BookingHotel_Application.Model.Models.DTO.Countries;

namespace BookingHotel_Application.BLL.Service
{
    public class CountryService : ICountryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CountryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseDTO> GetAllCountriesAsync()
        {
            var countries = await _unitOfWork.CountryRepository.GetAllAsync();
            var countriesDTOs = _mapper.Map<IEnumerable<CountriesDTO>>(countries);

            return new ResponseDTO
            {
                IsSucceed = true,
                Data = countriesDTOs
            };
        }

        public async Task<ResponseDTO> GetCountriesByIdAsync(int countryid)
        {
            var countries = await _unitOfWork.CountryRepository.GetByIdAsync(countryid);
            if (countries == null)
            {
                return new ResponseDTO
                {
                    IsSucceed = false,
                    Message = "Countries not found"
                };
            }

            var countriesDTOs = _mapper.Map<CountriesDTO>(countries);
            return new ResponseDTO
            {
                IsSucceed = true,
                Data = countriesDTOs
            };
        }

        public async Task<ResponseDTO> CreateCountriesAsync(CreateCountriesDTO createCountriesDTO)
        {
            var countries = _mapper.Map<Countries>(createCountriesDTO);
            await _unitOfWork.CountryRepository.AddAsync(countries);
            await _unitOfWork.SaveChangeAsync();

            return new ResponseDTO
            {
                IsSucceed = true,
                Message = "Countries created successfully"
            };
        }

        public async Task<ResponseDTO> UpdateCountriesAsync(int countryid, UpdateCountriesDTO updateCountriesDTO)
        {
            var countries = await _unitOfWork.CountryRepository.GetByIdAsync(countryid);
            if (countries == null)
            {
                return new ResponseDTO
                {
                    IsSucceed = false,
                    Message = "Countries not found"
                };
            }

            _mapper.Map(updateCountriesDTO, countries);
            var result = await _unitOfWork.CountryRepository.UpdateAsync(countries);

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
                Message = "Countries updated successfully"
            };
        }

        public async Task<ResponseDTO> DeleteCountriesAsync(int countryid)
        {
            await _unitOfWork.CountryRepository.DeleteAsync(countryid);
            await _unitOfWork.SaveChangeAsync();

            return new ResponseDTO
            {
                IsSucceed = true,
                Message = "Countries deleted successfully"
            };
        }
    }
}
