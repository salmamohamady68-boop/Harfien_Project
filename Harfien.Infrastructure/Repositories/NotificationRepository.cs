using Harfien.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harfien.Infrastructure.Repositories
{
    namespace Harfien.Infrastructure.Repositories
    {
        public class NotificationRepository
            : GenericRepository<Notification>, INotificationRepository
        {
            public NotificationRepository(ApplicationDbContext context)
                : base(context)
            {
            }

            public async Task<IEnumerable<Notification>> GetUserNotificationsAsync(int userId)
            {
                return await _dbSet
                    .Include(n => n.User)   // Eager Loading
                    .Where(n => n.UserId == userId)
                    .OrderByDescending(n => n.CreatedAt)
                    .ToListAsync();
            }
        }
    }



}
