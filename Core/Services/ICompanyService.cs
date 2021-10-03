﻿using Core.Entities;
using Core.Model.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface ICompanyService
    {
        Task<IEnumerable<User>> GetEmployeesWithUpcomingBirthdaysAsync(Guid companyId);
        Task<IEnumerable<Company>> GetCompaniesAsync();
        Task DeactivateCompanyAsync(Company company);
        Task CreateCompanyAsync(Company company);
        Task<bool> CheckCompanyPlanStatus(Guid companyID);
        Task<Company> GetCompanyByIDAsync(Guid companyID);
        Task UpdateCompanyAsync(Company company);
        Task SetCompanyApproveAsync(Guid companyID, bool status);
        Company GetCompanyByID(Guid companyID);

    }
}
