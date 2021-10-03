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
        private readonly IMapper mapper;

        public AdminController(IUserService _userService, ICompanyService _companyService, IMapper _mapper)
        {
            this.userService = _userService;
            this.companyService = _companyService;
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
        public async Task<IActionResult> SetCompanyApproveStatus(Guid companyId, bool status)
        {
            await companyService.SetCompanyApproveAsync(companyId, status);

            Company updateApprove = await companyService.GetCompanyByIDAsync(companyId);

            var updateCompanyApproved = mapper.Map<Company, CompanySaveDTO>(updateApprove);

            List<User> users = updateApprove.Users.Where(x => x.CompanyID == companyId).ToList();
            string role = string.Empty;
            foreach (User item in users)
            {
                role = await userService.GetUserRoleAsync(item.Id);
                if (role == "Employer")
                {
                    string content = "Your account has been approved.";
                    await userService.SendEmailToUserAsync(item.Email, EmailType.Activated, content);

                }
            }

            return Ok(updateCompanyApproved);
        }
        [HttpPost]
        public async Task<IActionResult> AddDayOffTypeName(DayOffDTO dayOffDTO)
        {
            if (ModelState.IsValid)
            {
                var dayOffTypeToCreate = mapper.Map<DayOffDTO, DayOffType>(dayOffDTO);
                DayOffType dayOffType = new DayOffType()
                {
                    DayOffTypeID = Guid.NewGuid(),
                    TypeName = dayOffDTO.TypeName,
                    Description = dayOffDTO.Description
                };
                await companyService.CreateDayOffTypeAsync(dayOffType);
                //var newDayOff = await userService.CreateDayOffTypeAsync(dayOffTypeToCreate);
            }
            return BadRequest(ModelState.Values.SelectMany(x => x.Errors).ToList());
        }
    }
}
