using AutoMapper;
using Core.Entities;
using Core.Model.Authentication;
using Core.Services;
using HRWebApi.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> RegisterEmployer(RegisterDTO registerDTO)
        {
            //modelstate, jquery validation ile kontrol edilecek
            var user = mapper.Map<RegisterDTO, User>(registerDTO);
            Company company = new Company()
            {
                CompanyID = Guid.NewGuid(),
                CompanyName = registerDTO.CompanyName,
                IsActive = true
            };
            user.CompanyID = company.CompanyID;
            List<string> errors = await userService.RegisterEmployerAsync(user, registerDTO.Password,company);
            if (errors != null)
            {
                return BadRequest(errors); //ajax ın error function ına gider
            }
            else
            {
                return Ok("Success"); // ajax ın success function ına gider
            }

        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers()
        //{
        //    var users = await adminService.GetAllUser();

        //    var adminDTO = mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(users);

        //    return Ok(adminDTO);
        //}
    }
}
