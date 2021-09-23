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
        Task<List<string>> RegisterEmployer(User user);
        Task<bool> LoginAsync(string email, string password, LoginType type);
    }
}
