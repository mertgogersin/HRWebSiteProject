using Core.Model.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IUserRepository:IRepository<User>
    {
        Task<bool> Login(string email, string password);
        //private void SetPassiveAllLinkedUsers(string companyID)
        Task SetUserToPassive(string userID);
        Task ActivateUser(string userID);
        Task<int> CountEmployees(string roleID); //employers da role id ye göre aynı metotta yazılabilir
        Task<IEnumerable<>>
    }
}
