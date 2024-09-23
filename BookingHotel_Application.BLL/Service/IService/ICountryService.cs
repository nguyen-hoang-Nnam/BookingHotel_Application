using BookingHotel_Application.Model.Models.DTO.Hotel;
using BookingHotel_Application.Model.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingHotel_Application.Model.Models.DTO.Countries;

namespace BookingHotel_Application.BLL.Service.IService
{
    public interface ICountryService
    {
        Task<ResponseDTO> GetAllCountriesAsync();
        Task<ResponseDTO> GetCountriesByIdAsync(int countryid);
        Task<ResponseDTO> CreateCountriesAsync(CreateCountriesDTO createCountriesDTO);
        Task<ResponseDTO> UpdateCountriesAsync(int countryid, UpdateCountriesDTO updateCountriesDTO);
        Task<ResponseDTO> DeleteCountriesAsync(int countryid);
    }
}
