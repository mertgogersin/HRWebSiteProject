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
        Task<List<string>> RegisterEmployerAsync(User user,string password);
        Task<bool> LoginAsync(string email, string password, LoginType type);
        Task ActivateUserAsync(Guid userID);
        Task SetUserToPassiveAsync(Guid userID);
        Task SendEmailToUserAsync(string email, EmailLinkType type, string content = null, string link = null);
        Task<string> ChangePassword(Guid userID, string password);
    }
}
