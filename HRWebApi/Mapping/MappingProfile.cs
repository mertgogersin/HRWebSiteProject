using AutoMapper;
using Core.Entities;
using Core.Model.Authentication;
using HRWebApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRWebApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterDTO, User>();

            CreateMap<User, UserDTO>();
        }
    }
}
