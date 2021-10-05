using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface INotificationService
    {
        Task<IEnumerable<Notification>> GetAllActiveNotificationsByUserIDAsync(Guid userID);
        Task<IEnumerable<Notification>> GetAllNotificationsByUserIDAsync(Guid userID);
        Task<Notification> GetNotificationByIdAsync(Guid notificationID);
        Task SetSeenAllNotificationsByUserIDAsync(Guid userID);
        Task<string> AddNotificationAsync(Notification notification);
        Task DeleteNotificationAsync(Guid notificationID);
    }
}
