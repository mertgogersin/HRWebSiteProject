using Core.Entities;
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
        private readonly Admin admin;
        public UserRepository(HRContext context, Admin admin) : base(context)
        {
            this.admin = admin;
        }
        private HRContext Context
        {
            get { return context; }
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await context.Users.Where(m => m.Email == email).FirstOrDefaultAsync();
        }

        public async Task<bool> Login(string email, string password, LoginType type)
        {
            bool check = false;
            switch (type)
            {
                case LoginType.Admin:
                    if (admin.Email == email && admin.Password == password)
                    {
                        check = true;
                    }
                    break;
                case LoginType.User:
                    foreach (User item in await GetAllAsync())
                    {
                        if (item.Email == email && item.PasswordHash == password)
                        {
                            check = true;
                        }
                    }
                    break;
            }
            return await Task.FromResult(check);
        }
    }
}
