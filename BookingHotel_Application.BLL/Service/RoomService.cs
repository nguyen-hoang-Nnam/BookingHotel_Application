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
using BookingHotel_Application.Model.Models.DTO.Room;
using BookingHotel_Application.Model.Enum;

namespace BookingHotel_Application.BLL.Service
{
    public class RoomService : IRoomService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoomService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseDTO> GetAllRoomAsync()
        {
            var rooms = await _unitOfWork.RoomRepository.GetAll();
            var roomDTOs = _mapper.Map<IEnumerable<RoomDTO>>(rooms);

            return new ResponseDTO
            {
                IsSucceed = true,
                Data = roomDTOs
            };
        }

        public async Task<ResponseDTO> GetRoomByIdAsync(int roomid)
        {
            var room = await _unitOfWork.RoomRepository.GetById(roomid);
            if (room == null)
            {
                return new ResponseDTO
                {
                    IsSucceed = false,
                    Message = "Room not found"
                };
            }

            var roomDTO = _mapper.Map<RoomDTO>(room);
            return new ResponseDTO
            {
                IsSucceed = true,
                Data = roomDTO
            };
        }

        public async Task<ResponseDTO> CreateRoomAsync(CreateRoomDTO createroomDTO)
        {
            var roomType = await _unitOfWork.RoomTypeRepository.GetByIdAsync(createroomDTO.roomTypeId);
            if (roomType == null)
            {
                return new ResponseDTO
                {
                    IsSucceed = false,
                    Message = "Room Type not found."
                };
            }
            var hotel = await _unitOfWork.HotelRepository.GetByIdAsync(createroomDTO.hotelId);
            if (hotel == null)
            {
                return new ResponseDTO
                {
                    IsSucceed = false,
                    Message = "Hotel not found."
                };
            }
            var room = _mapper.Map<Room>(createroomDTO);
            room.Hotel = hotel;
            room.RoomType = roomType;
            room.roomStatus = Model.Enum.RoomStatus.Active;
            await _unitOfWork.RoomRepository.AddAsync(room);
            await _unitOfWork.SaveChangeAsync();

            return new ResponseDTO
            {
                IsSucceed = true,
                Message = "Room created successfully",
                Data = room
            };
        }

        public async Task<ResponseDTO> UpdateRoomAsync(int roomid)
        {
            var room = await _unitOfWork.RoomRepository.GetByIdAsync(roomid);

            if (room == null)
            {
                return new ResponseDTO
                {
                    IsSucceed = false,
                    Message = "Room not found"
                };
            }

            room.roomStatus = RoomStatus.Active;

            var result = await _unitOfWork.RoomRepository.UpdateAsync(room);

            if (!result)
            {
                return new ResponseDTO
                {
                    IsSucceed = false,
                    Message = "Update failed",
                    Data = result
                };
            }

            await _unitOfWork.SaveChangeAsync();

            return new ResponseDTO
            {
                IsSucceed = true,
                Message = "Room status updated to Active successfully"
            };
        }


        public async Task<ResponseDTO> DeleteRoomAsync(int roomid)
        {
            await _unitOfWork.RoomRepository.DeleteAsync(roomid);
            await _unitOfWork.SaveChangeAsync();

            return new ResponseDTO
            {
                IsSucceed = true,
                Message = "Room deleted successfully"
            };
        }
        public async Task<ResponseDTO> GetRoomsByRoomTypeIdAsync(int roomTypeId)
        {
            var rooms = await _unitOfWork.RoomRepository.GetRoomByRoomTypeIdAsync(roomTypeId);

            if (!rooms.Any())
            {
                return new ResponseDTO
                {
                    IsSucceed = false,
                    Message = "No Rooms found for the given Room Type."
                };
            }

            var roomDTOs = _mapper.Map<IEnumerable<RoomDTO>>(rooms);

            return new ResponseDTO
            {
                IsSucceed = true,
                Data = roomDTOs
            };
        }

        public async Task<ResponseDTO> GetRoomsByHotelIdAsync(int hotelId)
        {
            var rooms = await _unitOfWork.RoomRepository.GetRoomByHotelIdAsync(hotelId);
            if (!rooms.Any())
            {
                return new ResponseDTO
                {
                    IsSucceed = false,
                    Message = "No Rooms found for the given Hotel."
                };
            }

            var hotel = rooms.First().Hotel;

            var hotelWithRoomsDTO = _mapper.Map<HotelWithRoomsDTO>(hotel);
            hotelWithRoomsDTO.Rooms = _mapper.Map<List<RoomDTO>>(rooms);

            return new ResponseDTO
            {
                IsSucceed = true,
                Data = hotelWithRoomsDTO
            };
        }
    }
}
