using AutoMapper;
using BookingHotel_Application.BLL.Service.IService;
using BookingHotel_Application.DAL.UoW.IUoW;
using BookingHotel_Application.Model.Models.DTO.Countries;
using BookingHotel_Application.Model.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingHotel_Application.Model.Models.DTO.Comment;
using BookingHotel_Application.Model.Models;

namespace BookingHotel_Application.BLL.Service
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseDTO> GetAllCommentsAsync()
        {
            var comments = await _unitOfWork.CommentRepository.GetAll();
            var commentDTOs = _mapper.Map<IEnumerable<CommentDTO>>(comments);

            return new ResponseDTO
            {
                IsSucceed = true,
                Data = commentDTOs
            };
        }

        public async Task<ResponseDTO> GetCommentByIdAsync(int commentId)
        {
            var comments = await _unitOfWork.CommentRepository.GetById(commentId);
            if (comments == null)
            {
                return new ResponseDTO
                {
                    IsSucceed = false,
                    Message = "Comments not found"
                };
            }

            var commentDTOs = _mapper.Map<CommentDTO>(comments);
            return new ResponseDTO
            {
                IsSucceed = true,
                Data = commentDTOs
            };
        }

        public async Task<ResponseDTO> AddCommentAsync(CreateCommentDTO createCommentDTO)
        {
            var hotel = await _unitOfWork.HotelRepository.GetByIdAsync(createCommentDTO.hotelId);
            var user = await _unitOfWork.UserRepository.GetByIdAsync(createCommentDTO.userId);

            if (hotel == null || user == null)
            {
                return new ResponseDTO { IsSucceed = false, Message = "Hotel or User not found" };
            }

            var comment = _mapper.Map<Comment>(createCommentDTO);
            comment.commentDate = DateTime.UtcNow;
            comment.Hotel = hotel;
            comment.User = user;

            await _unitOfWork.CommentRepository.AddAsync(comment);
            await _unitOfWork.SaveChangeAsync();

            return new ResponseDTO { IsSucceed = true, Message = "Comment added successfully" };
        }

        public async Task<ResponseDTO> UpdateCommentAsync(UpdateCommentDTO updateCommentDTO)
        {
            var comment = await _unitOfWork.CommentRepository.GetByIdAsync(updateCommentDTO.commentId);
            if (comment == null)
            {
                return new ResponseDTO { IsSucceed = false, Message = "Comment not found" };
            }

            _mapper.Map(updateCommentDTO, comment);
            await _unitOfWork.SaveChangeAsync();

            return new ResponseDTO { IsSucceed = true, Message = "Comment updated successfully" };
        }

        public async Task<ResponseDTO> DeleteCommentAsync(int commentId)
        {

            await _unitOfWork.CommentRepository.DeleteAsync(commentId);
            await _unitOfWork.SaveChangeAsync();

            return new ResponseDTO { IsSucceed = true, Message = "Comment deleted successfully" };
        }

    }
}
