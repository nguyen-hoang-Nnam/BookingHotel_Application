using AutoMapper;
using BookingHotel_Application.BLL.Service.IService;
using BookingHotel_Application.DAL.UoW.IUoW;
using BookingHotel_Application.Model.Models.DTO.Countries;
using BookingHotel_Application.Model.Models.DTO;
using BookingHotel_Application.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingHotel_Application.Model.Models.DTO.RoomType;

namespace BookingHotel_Application.BLL.Service
{
    public class RoomTypeService : IRoomTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoomTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseDTO> GetAllRoomTypeAsync()
        {
            var roomtypes = await _unitOfWork.RoomTypeRepository.GetAllAsync();
            var roomtypesDTOs = _mapper.Map<IEnumerable<RoomTypeDTO>>(roomtypes);

            return new ResponseDTO
            {
                IsSucceed = true,
                Data = roomtypesDTOs
            };
        }

        public async Task<ResponseDTO> GetRoomTypeByIdAsync(int roomtypeid)
        {
            var roomtypes = await _unitOfWork.RoomTypeRepository.GetByIdAsync(roomtypeid);
            if (roomtypes == null)
            {
                return new ResponseDTO
                {
                    IsSucceed = false,
                    Message = "Room Type not found"
                };
            }

            var roomtypesDTOs = _mapper.Map<RoomTypeDTO>(roomtypes);
            return new ResponseDTO
            {
                IsSucceed = true,
                Data = roomtypesDTOs
            };
        }

        public async Task<ResponseDTO> CreateRoomTypeAsync(CreateRoomTypeDTO createRoomTypeDTO)
        {
            var roomtypes = _mapper.Map<RoomType>(createRoomTypeDTO);
            await _unitOfWork.RoomTypeRepository.AddAsync(roomtypes);
            await _unitOfWork.SaveChangeAsync();

            return new ResponseDTO
            {
                IsSucceed = true,
                Message = "Room type created successfully"
            };
        }

        public async Task<ResponseDTO> UpdateRoomTypeAsync(int roomtypeid, UpdateRoomTypeDTO updateRoomTypeDTO)
        {
            var roomtypes = await _unitOfWork.RoomTypeRepository.GetByIdAsync(roomtypeid);
            if (roomtypes == null)
            {
                return new ResponseDTO
                {
                    IsSucceed = false,
                    Message = "Room type not found"
                };
            }

            _mapper.Map(updateRoomTypeDTO, roomtypes);
            var result = await _unitOfWork.RoomTypeRepository.UpdateAsync(roomtypes);

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
                Message = "Room type updated successfully"
            };
        }

        public async Task<ResponseDTO> DeleteRoomTypeAsync(int roomtypeid)
        {
            await _unitOfWork.RoomTypeRepository.DeleteAsync(roomtypeid);
            await _unitOfWork.SaveChangeAsync();

            return new ResponseDTO
            {
                IsSucceed = true,
                Message = "Room type deleted successfully"
            };
        }
    }
}
