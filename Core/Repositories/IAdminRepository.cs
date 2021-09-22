using Core.Entities;
using Core.Enums;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IAdminRepository
    {
        Task SetSubscriptionPlanForUser(string userID, int planID);                           
        Task ActivateUser(string userID);

    }
}
