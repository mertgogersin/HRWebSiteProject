using AutoMapper;
using Core.Entities;
using Core.Model.Authentication;
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
    public class AdminController : ControllerBase
    {
        private readonly ICompanyService companyService;
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public AdminController(IUserService _userService,ICompanyService _companyService,IMapper _mapper)
        {
            this.userService = _userService;
            this.companyService = _companyService;
            this.mapper = _mapper;
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<UserDTO>> SetEmployerStatus(Guid id, bool status)
        {
            await userService.SetUserStatus(id, status);

            var updatedActive = await userService.GetUseryByIDAsync(id);

            var updateCompanyActivated = mapper.Map<User, UserDTO>(updatedActive);

            return Ok(updateCompanyActivated);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<CompanyDTO>> SetCompanyApproveStatus(Guid id, bool status)
        {
            await companyService.SetCompanyApprove(id, status);

            var updateApprove = await companyService.GetCompanyByIDAsync(id);

            var updateCompanyApproved = mapper.Map<Company, CompanyDTO>(updateApprove);

            return Ok(updateCompanyApproved);
        }

    }
}
