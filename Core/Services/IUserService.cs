using Core.Entities;
using Core.Enums;
using Core.Model.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IUserService
    {
        Task<List<string>> RegisterEmployerAsync(User user, string password);
        Task<bool> LoginAsync(string email, string password, LoginType type);
        Task<IEnumerable<User>> GetUsersAsync();
        List<User> GetEmployees(Guid companyId);
        Task ActivateUserAsync(Guid userID);
        Task SetUserToPassiveAsync(Guid userID);
        User GetUserByID(Guid userID);      
        Task<User> GetUserByEmailAsync(string email);
        Task<List<string>> UpdateUserInfoAsync(User user);
        Task SetUserStatus(Guid userID, bool status);
        Task<User> GetUserByIDAsync(Guid userID);
        Task<string> GetUserRoleAsync(Guid userID);

    }
}
