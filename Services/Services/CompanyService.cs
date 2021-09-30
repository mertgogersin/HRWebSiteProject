using Core.Entities;
using Core.Model.Authentication;
using Core.Services;
using Core.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork unitOfWork;

        public CompanyService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task<bool> CheckCompanyPlanStatus(Guid companyID)
        {
            Company company = (Company)unitOfWork.Companies.List(m => m.CompanyID == companyID);
            if (company.PlanID != null) { return Task.FromResult(true); }
            return Task.FromResult(false);
        }

        public async Task DeactivateCompanyAsync(Company company)
        {
            company.IsActive = false;
            unitOfWork.Companies.Delete(company);
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Company>> GetCompaniesAsync()
        {
            return await unitOfWork.Companies.GetAllAsync();
        }


        public async Task<Company> GetCompanyByIDAsync(Guid companyID)
        {
            return await unitOfWork.Companies.GetByIdAsync(companyID);
        }

        public async Task<IEnumerable<User>> GetEmployeesWithUpcomingBirthdaysAsync(Guid companyId)
        {
            List<User> employees = new List<User>();
            foreach (User item in await unitOfWork.Users.GetAllAsync())
            {
                DateTime today = DateTime.Today;
                DateTime next = new DateTime(today.Year, item.BirthDate.Value.Month, item.BirthDate.Value.Day);
                if (next < today) next = next.AddYears(1);
                int numDays = (next - today).Days;
                if (numDays <= 30) employees.Add(item);
            }
            return employees;
        }

        public async Task UpdateCompany(Company companyToUpdate, Company company)
        {
            companyToUpdate.CompanyName = company.CompanyName;
            companyToUpdate.Description = company.Description;
            companyToUpdate.Address = company.Address;
            companyToUpdate.Comment = company.Comment;
            companyToUpdate.IsActive = company.IsActive;
            companyToUpdate.Logo = company.Logo;

            await unitOfWork.CommitAsync();
        }
        public async Task SetCompanyApprove(Guid companyID, bool status)
        {
            Company company = (Company)unitOfWork.Companies.List(x => x.CompanyID == companyID);

            if (!status)
                company.IsApprove = false;
            else
                company.IsApprove = true;

            await unitOfWork.CommitAsync();
        }

        public Company GetCompanyByID(Guid companyID)
        {
            return unitOfWork.Companies.List(x => x.CompanyID == companyID).FirstOrDefault();
        }


    }
}
