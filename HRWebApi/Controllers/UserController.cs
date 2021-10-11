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
        private readonly ICompanyService companyService;
        private readonly IMapper mapper;

        public UserController(IUserService userService, IMapper mapper, ICompanyService companyService)
        {
            this.userService = userService;
            this.companyService = companyService;
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
                await companyService.CreateCompanyAsync(company);
                user.CompanyID = company.CompanyID;
                List<string> errors = await userService.RegisterEmployerAsync(user, registerDTO.Password);
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeactivateUser(Guid id)
        {
            await userService.SetUserStatus(id, false);
            return Ok("User is successfully deactivated.");
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            IEnumerable<User> users = await userService.GetUsersAsync();

            IEnumerable<UserDTO> userDTOs = mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(users);

            return Ok(userDTOs);
        }
        [HttpGet("{id}")]
        public IActionResult GetCompanyUsers(Guid id)
        {
            IEnumerable<User> users = userService.GetEmployees(id, true);
            return Ok(users);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUserInfo(UserDTO userDTO) //userdto propertyleri değişebilir
        {
            if (ModelState.IsValid)
            {
                User userToBeUpdated = userService.GetUserByID(userDTO.UserID);
                User user = mapper.Map(userDTO, userToBeUpdated);
                List<string> errors = await userService.UpdateUserInfoAsync(user);
                if (errors != null) { return BadRequest(errors); }
                return Ok("User is successfully updated!");
            }
            return BadRequest(ModelState.Values.SelectMany(x => x.Errors).ToList());
        }

    }
}
