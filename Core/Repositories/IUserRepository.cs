using Core.Enums;
using Core.Model.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IUserRepository:IRepository<User>,IEmailRepository
    {
        Task<bool> Login(string email, string password);
        //private void SetPassiveAllLinkedUsers(string companyID)
        Task SetUserToPassive(string userID);
        //Task SendRegisterMailToUser(string userID, string link);//update user(isActive)
        //Task SendPasswordRenewalMailToUser(string userID, string link);//update user ile çözülür (password sadece)
        
        
        //approve disapprove Role: Employer
        Task SetUserExpenseStatus(int expenseID, bool status);
        Task SetUserOffDayStatus(int offdayID, bool status);
        //Role: Emploee
        Task SetUserDebitStatus(int debitID, bool status);
    }
}
