using BookingHotel_Application.BLL.Service.IService;
using BookingHotel_Application.Model.Models.DTO.Comment;
using BookingHotel_Application.Model.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        // Get All Comments
        [HttpGet("GetAllComments")]
        public async Task<IActionResult> GetAllComments()
        {
            var comments = await _commentService.GetAllCommentsAsync();
            return Ok(comments);
        }

        // Get Comment by Id
        [HttpGet]
        [Route("GetCommentById/{id:int}")]
        public async Task<IActionResult> GetCommentById(int id)
        {
            var comment = await _commentService.GetCommentByIdAsync(id);
            if (comment == null)
            {
                return NotFound(new ResponseDTO { IsSucceed = false, Message = "Comment not found" });
            }
            return Ok(comment);
        }

        // Add Comment
        [HttpPost("AddComment")]
        public async Task<IActionResult> AddComment([FromBody] CreateCommentDTO createCommentDTO)
        {
            var result = await _commentService.AddCommentAsync(createCommentDTO);
            if (result.IsSucceed)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        // Update Comment
        [HttpPut]
        [Route("UpdateComment/{id:int}")]
        public async Task<IActionResult> UpdateComment([FromBody] UpdateCommentDTO updateCommentDTO)
        {
            var result = await _commentService.UpdateCommentAsync(updateCommentDTO);
            if (result.IsSucceed)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        // Delete Comment
        [HttpDelete]
        [Route("DeleteComment/{id:int}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var result = await _commentService.DeleteCommentAsync(id);
            if (result.IsSucceed)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
