using AutoMapper;
using Core.Entities;
using Core.Services;
using HRWebApi.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService commentService;
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public CommentController(ICommentService _commentService, IUserService _userService, IMapper _mapper)
        {
            this.commentService = _commentService;
            this.userService = _userService;
            this.mapper = _mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllComments()
        {
            IEnumerable<Comment> comments = await commentService.GetCommentsAsync();
            IEnumerable<CommentDTO> commentDTOs = mapper.Map<IEnumerable<Comment>, IEnumerable<CommentDTO>>(comments);
            return Ok(commentDTOs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentsByCompanyID(Guid id)
        {
            List<Comment> comments = (List<Comment>)await commentService.GetAllCommentsByCompanyIDAsync(id);
            List<CommentDTO> commentDTOs = mapper.Map<List<Comment>, List<CommentDTO>>(comments);
            return Ok(commentDTOs);
        }
        [HttpPost]
        public async Task<IActionResult> AddComment(CommentDTO commentDTO)
        {
            if (ModelState.IsValid)
            {
                Comment comment = mapper.Map<CommentDTO, Comment>(commentDTO);
                string error = await commentService.AddCommentAsync(comment);
                if (error != null)
                    return BadRequest(error);

                return Ok("Comment added.");
            }
            return BadRequest(ModelState.Values.SelectMany(x => x.Errors).ToList());
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCommentInfo(CommentDTO commentDTO)
        {
            if(ModelState.IsValid)
            {
                Comment commentToBeUpdated = await commentService.GetCommentByIDAsync(commentDTO.CommentID);
                Comment comment = mapper.Map(commentDTO, commentToBeUpdated);
                string error = await commentService.UpdateCommentAsync(comment);
                if (error != null)
                    return BadRequest(error);
                return Ok("Comment successfully updated.");
            }
            return BadRequest(ModelState.Values.SelectMany(x => x.Errors).ToList());
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(Guid id)
        {
            await commentService.DeleteCommentAsync(id);
            return Ok("Comment successfully deleted.");
        }
        [HttpGet("{id}")]
        public IActionResult GetCommentByCompany(Guid id)
        {
            IEnumerable<Comment> comments = commentService.GetCompany(id);
            return Ok(comments);
        }

    }
}
