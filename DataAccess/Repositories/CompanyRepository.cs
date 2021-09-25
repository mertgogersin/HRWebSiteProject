using Core.Entities;
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
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(HRContext context) : base(context)
        {

        }
        private HRContext Context
        {
            get { return context; }
        }

        public async Task<Company> GetCompanyByIDAsync(Guid companyID)
        {
            return await Context.Companies.FindAsync(companyID);
        }

        public async Task<IEnumerable<User>> GetPersonnelListAsync(Guid companyID, Guid roleID) //compid string olacak
        {
            List<User> personnels =await (from user in Context.Users
                          join userRole in Context.UserRoles on user.Id equals userRole.UserId
                          join role in Context.Roles on userRole.RoleId equals role.Id
                          where user.CompanyID == companyID && role.Id == roleID
                          select user).ToListAsync();
            return personnels;
        }

        //public Task SetSubscriptionPlanForCompany(string companyID, int planID) bu da update ile yapılacak
        //{
        //    Company company = context.Companies.Where(m => m.CompanyID == Guid.Parse(companyID) && m.IsActive && m.IsApprove).FirstOrDefault();
        //    company.PlanID = planID;
        //}
    }
}
