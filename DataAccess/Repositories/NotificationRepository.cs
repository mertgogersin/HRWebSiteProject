using Core.Entities;
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
    public class NotificationRepository:Repository<Notification>,INotificationRepository
    {
        public NotificationRepository(HRContext context):base(context)
        {
            
        }
        private HRContext Context
        {
            get { return context; }
        }

        public async Task<IEnumerable<Notification>> GetNotificationsByUserID(Guid userID)
        {
            return await context.Notifications.Where(m => m.UserID == userID).ToListAsync();
        }
    }
}
