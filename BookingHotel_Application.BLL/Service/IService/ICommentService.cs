using BookingHotel_Application.Model.Models.DTO.Comment;
using BookingHotel_Application.Model.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel_Application.BLL.Service.IService
{
    public interface ICommentService
    {
        Task<ResponseDTO> GetAllCommentsAsync();
        Task<ResponseDTO> GetCommentByIdAsync(int commentId);
        Task<ResponseDTO> AddCommentAsync(CreateCommentDTO createCommentDTO);
        Task<ResponseDTO> UpdateCommentAsync(UpdateCommentDTO updateCommentDTO);
        Task<ResponseDTO> DeleteCommentAsync(int commentId);
    }
}
