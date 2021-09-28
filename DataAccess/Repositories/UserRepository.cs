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
        
        public UserRepository(HRContext context) : base(context)
        {
        }
        private HRContext Context
        {
            get { return context; }
        }

        public async Task<IEnumerable<User>> GetAllWithCompanyByCompanyID(Guid companyId)
        {
            return await Context.Users
                .Include(x => x.Company)
                .Where(x => x.CompanyID == companyId).ToListAsync();
        }

        public async Task<User> GetUserByPhoneNumberAsync(string phone)
        {
            return await Context.Users.Where(m => m.PhoneNumber == phone).FirstOrDefaultAsync();
        }

        
    }
}
