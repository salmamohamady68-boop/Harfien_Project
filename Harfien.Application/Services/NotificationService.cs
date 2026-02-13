using Harfien.Application.Interfaces;
using Harfien.Domain.Entities;
using Harfien.Domain.Interface_Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harfien.Application.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationService(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task<IEnumerable<Notification>> GetUserNotificationsAsync(string userId)
        {
            return await _notificationRepository.GetByUserIdAsync(userId);
        }

        public async Task MarkAsReadAsync(int notificationId)
        {
            var notification = await _notificationRepository.GetByIdAsync(notificationId);

            if (notification == null)
                throw new Exception("Notification not found");

            notification.IsRead = true;

            await _notificationRepository.SaveChangesAsync();
        }
    }
}
