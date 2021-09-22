﻿using Core.Entities;
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

        public async Task<Company> GetCompanyByID(string companyID)
        {
            return await context.Companies.FindAsync(Guid.Parse(companyID));
        }

        public async Task<IEnumerable<User>> GetPersonnelList(int companyID, string roleID) //compid string olacak
        {
            List<User> personnels =await (from user in context.Users
                          join userRole in context.UserRoles on user.Id equals userRole.UserId
                          join role in context.Roles on userRole.RoleId equals role.Id
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
