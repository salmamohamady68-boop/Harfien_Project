using Harfien.Application.DTO.Error;
using Harfien.Application.Helpers;
using Harfien.Application.Interfaces;
using Harfien.Domain.Entities;
using Harfien.Domain.Interface_Repository.Repositories;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Harfien.Application.DTO.Notifications;

namespace Harfien.Application.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationService(INotificationRepository notificationRepository,
                               IHubContext<NotificationHub> hubContext)
        {
            _notificationRepository = notificationRepository;
            this._hubContext = hubContext;
        }
        // 🔹 ترجع NotificationDto
        public async Task<IEnumerable<NotificationDto>> GetUserNotificationsDtoAsync(string userId)
        {
            var notifications = await _notificationRepository.GetByUserIdAsync(userId);

            return notifications.Select(n => new NotificationDto
            {
                Id = n.Id,
                UserId = n.UserId,      // مهم للفرونت
                Title = n.Title,
                Message = n.Message,
                CreatedAt = n.CreatedAt,
                IsRead = n.IsRead
            }).ToList();
        }

        // 🔹 ترجع Notification مباشرة
        public async Task<IEnumerable<Notification>> GetUserNotificationsAsync(string userId)
        {
            return await _notificationRepository.GetByUserIdAsync(userId);
        }

        public async Task<ServiceResult<bool>> MarkAsReadAsync(int notificationId)
        {
            var notification = await _notificationRepository.GetByIdAsync(notificationId);

            if (notification == null)
            {
                return ServiceResult<bool>.Failure(
                    "Notification not found",
                    new List<FieldErrorDto>
                    {
                new FieldErrorDto
                {
                    Field = "notificationId",
                    Message = "Invalid notification id"
                }
                    });
            }

            notification.IsRead = true;
            await _notificationRepository.SaveChangesAsync();

        public async Task CreateNotificationAsync(string userId, string title, string message)
        {
            var notification = new Notification
            {
                UserId = userId,
                Title = title,
                Message = message
            };

            await _notificationRepository.AddAsync(notification);
            await _notificationRepository.SaveChangesAsync();

            await _hubContext.Clients.User(userId)
                .SendAsync("ReceiveNotification", new
                {
                    notification.Id,
                    notification.UserId,   // مهم للفرونت
                    notification.Title,
                    notification.Message,
                    notification.CreatedAt
                });
        }

        public async Task SendToMultipleUsersAsync(List<string> userIds, string title, string message)
        {
            foreach (var userId in userIds)
            {
                await CreateNotificationAsync(userId, title, message);
            }
        }
    }
}
