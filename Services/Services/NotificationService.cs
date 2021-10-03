using Core.Entities;
using Core.Services;
using Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IUnitOfWork unitOfWork;
        public NotificationService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<string> AddNotificationAsync(Notification notification)
        {
            string error = null;
            try
            {
                await unitOfWork.Notifications.AddAsync(notification);
                await unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                error = "Notification couldn't be added!";
            }

            return error;
        }

        public async Task DeleteNotificationAsync(Guid notificationID)
        {
            Notification notificationToDelete = await unitOfWork.Notifications.GetByIdAsync(notificationID);
            notificationToDelete.IsActive = false;
            unitOfWork.Notifications.Delete(notificationToDelete);
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Notification>> GetAllNotificationsByUserIDAsync(Guid userID)
        {
            return await Task.FromResult(unitOfWork.Notifications.List(m => m.UserID == userID));
        }
        public async Task<IEnumerable<Notification>> GetAllActiveNotificationsByUserIDAsync(Guid userID)
        {
            List<Notification> notifications = (List<Notification>)await GetAllNotificationsByUserIDAsync(userID);
            return notifications.Where(m => m.IsActive);
        }
        public async Task SetSeenAllNotificationsByUserIDAsync(Guid userID) //bildirimler sayfasına girdiğinde bütün bildirimleri görüldü yapacak.
        {
            foreach (Notification item in await GetAllActiveNotificationsByUserIDAsync(userID)) 
            { item.IsSeen = true; unitOfWork.Notifications.Update(item); }
            await unitOfWork.CommitAsync();
        }
        public async Task<Notification> GetNotificationByIdAsync(Guid notificationID)
        {
            return await unitOfWork.Notifications.GetByIdAsync(notificationID);
        }

        public async Task<string> UpdateNotificationAsync(Notification notification)
        {
            string error = null;
            try
            {
                unitOfWork.Notifications.Update(notification);
                await unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                error = "Notification couldn't be updated";
            }
            return error;
        }
    }
}
