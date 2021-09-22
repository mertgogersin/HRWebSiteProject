using Core.Entities;
using Core.Enums;
using Core.Model.Authentication;
using Core.Repositories;
using DataAccess.Context;
using DataAccess.Repositories.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        HRContext context;
        public AdminRepository(HRContext context)
        {
            this.context = context;
        }
        public async Task ActivateUser(string userID)
        {
            User user = context.Users.Find(userID);
            user.IsActive = true; //isapprove olacak burası
            await context.SaveChangesAsync();
        }         
        public Task SetSubscriptionPlanForUser(string userID, int planID)
        {
            //db tabloları bitince yapılacak
            throw new NotImplementedException();
        }
     
    }
}
