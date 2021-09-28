using AutoMapper;
using Core.Entities;
using Core.Enums;
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
            if (ModelState.IsValid)
            {
                var user = mapper.Map<RegisterDTO, User>(registerDTO);
                Company company = new Company()
                {
                    CompanyID = Guid.NewGuid(),
                    CompanyName = registerDTO.CompanyName,
                    IsActive = true
                };
                user.CompanyID = company.CompanyID;
                List<string> errors = await userService.RegisterEmployerAsync(user, registerDTO.Password, company);
                if (errors != null)
                {
                    return BadRequest(errors); //ajax ın error function ına gider
                }
                string token = await userService.GenerateEmailConfirmationTokenAsync(user);
                var confirmationLink = "<a href='"
                    + Url.Action("ActivateUser", "Register", new { token = token }, Request.Scheme) //mvc deki action controller a linkleriz.(ActivateUser: Action, Register: Controller)
                    + "'>Click here</a>";
                await userService.SendEmailToUserAsync(user.Email, EmailType.Register, confirmationLink);
                return Ok("Email has been sent, please check your inbox."); // ajax ın success function ına gider. mvc kısmında token validate edilecek              
            }
            return BadRequest(ModelState.Values.SelectMany(x => x.Errors).ToList());

        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (ModelState.IsValid)
            {
                bool check = await userService.LoginAsync(loginDTO.Email, loginDTO.Password, LoginType.User);
                if (check)
                {
                    return Ok(userService.GetUserByEmailAsync(loginDTO.Email));
                }
                return BadRequest("Login attempt is invalid");
            }
            return BadRequest(ModelState.Values.SelectMany(x => x.Errors).ToList());
        }


    }
}
