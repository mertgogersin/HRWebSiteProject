using AutoMapper;
using Core.Entities;
using Core.Enums;
using Core.Model.Authentication;
using Core.Services;
using HRWebApi.DTO;
using HRWebApi.Validators;
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
    public class AdminController : ControllerBase
    {
        private readonly ICompanyService companyService;
        private readonly IUserService userService;
        private readonly IDayOffService dayOffService;
        private readonly IMapper mapper;

        public AdminController(IUserService _userService, ICompanyService _companyService, IDayOffService _dayOffService, IMapper _mapper)
        {
            this.userService = _userService;
            this.companyService = _companyService;
            this.dayOffService = _dayOffService;
            this.mapper = _mapper;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> SetEmployerStatus(Guid id, bool status)
        {

            await userService.SetUserStatus(id, status);

            User updatedActive = await userService.GetUserByIDAsync(id);

            var updateCompanyActivated = mapper.Map<User, UserDTO>(updatedActive);

            return Ok(updateCompanyActivated);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> SetCompanyStatus(Guid id)
        {
            bool status = await companyService.SetCompanyStatusAsync(id);

            Company updateApprove = await companyService.GetCompanyByIDAsync(id);

            CompanySaveDTO updateCompanyApproved = mapper.Map<Company, CompanySaveDTO>(updateApprove);

            List<User> users = updateApprove.Users.Where(x => x.CompanyID == id).ToList();
            string role = string.Empty;
            foreach (User item in users)
            {
                role = await userService.GetUserRoleAsync(item.Id);
                if (role == "Employer")
                {
                    string content = "Your account has been approved.";
                    if (!status) { content = "Your account has been disapproved."; }
                    await userService.SendEmailToUserAsync(item.Email, EmailType.Activated, content);

                }
            }

            return Ok(updateCompanyApproved);
        }
       
    }
}
