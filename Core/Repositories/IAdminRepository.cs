using Core.Entities;
using Core.Enums;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IAdminRepository:IEmailRepository
    {
        Task SetSubscriptionPlanForUser(string id, SubscriptionPlans type);
        Task UpdateCompanyInfo(Company company);      
        Task SetPassiveCompany(string company);


    }
}
