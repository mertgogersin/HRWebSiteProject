﻿using Core.Entities;
using Core.Enums;
using Core.Model.Authentication;
using Core.Repositories;
using DataAccess.Context;
using DataAccess.Repositories.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        
        public UserRepository(HRContext context) : base(context)
        {
        }
        private HRContext Context
        {
            get { return context; }
        }

        public async Task<User> GetUserByPhoneNumber(string phone)
        {
            return await Context.Users.Where(m => m.PhoneNumber == phone).FirstOrDefaultAsync();
        }

        
    }
}
