﻿using AutoMapper;
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
    [Route("api/[controller]")]
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
            List<string> errors = await userService.RegisterEmployerAsync(user, registerDTO.Password);
            if (errors != null)
            {
                return BadRequest(errors); //ajax ın error function ına gider
            }
            else
            {
                return Ok("Success"); // ajax ın success function ına gider
            }

        }
    }
}
