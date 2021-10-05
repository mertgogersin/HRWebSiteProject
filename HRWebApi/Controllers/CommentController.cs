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
        private readonly IMapper mapper;

        public CommentController(ICommentService _commentService, IMapper _mapper)
        {
            this.commentService = _commentService;
            this.mapper = _mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllComments()
        {
            IEnumerable<Comment> comments = await commentService.GetCommentsAsync();
            IEnumerable<CommentDTO> commentDTOs = mapper.Map<IEnumerable<Comment>, IEnumerable<CommentDTO>>(comments);
            return Ok(commentDTOs);
        }
    }
}
