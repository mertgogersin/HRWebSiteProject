using Core.Entities;
using Core.Repositories;
using DataAccess.Context;
using DataAccess.Repositories.Generics;
using Microsoft.EntityFrameworkCore;
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

        
    }
}
