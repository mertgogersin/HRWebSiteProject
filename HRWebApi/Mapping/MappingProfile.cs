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

            CreateMap<DayOffDTO, DayOff>();
            CreateMap<DayOff, DayOffDTO>();

            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

            CreateMap<Company, CompanySaveDTO>();
            CreateMap<CompanySaveDTO, Company>();

            CreateMap<Comment, CommentDTO>(); 
            CreateMap<CommentDTO, Comment>();

            CreateMap<User, UpcomingBirthdaysDTO>();

            CreateMap<DebitDTO, Debit>();
            CreateMap<Debit, DebitDTO>();
            
            CreateMap<NotificationDTO, Notification>();
            CreateMap<Notification, NotificationDTO>();

            CreateMap<FileType, FileTypeDTO>();

            CreateMap<File, GetFileDTO>();
            CreateMap<SaveFileDTO, File>();

            CreateMap<Expense, ExpenseDTO>();
            CreateMap<ExpenseDTO, Expense>();

            CreateMap<Shift, ShiftDTO>();
            CreateMap<ShiftDTO, Shift>();

        }
    }
}
