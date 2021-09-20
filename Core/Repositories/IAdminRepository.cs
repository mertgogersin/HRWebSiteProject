using Core.Entities;
using Core.Enums;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IAdminRepository
    {
        Task SetSubscriptionPlanForUser(string id, SubscriptionPlans type);
        Task UpdateCompanyInfo(Company company);
        Task SendNotificationMailToUser(string email,string link);
        Task SetPassiveCompany(string company);
        Task SetVacationType(Vacation vacation); //revize yapılacak


    }
}
