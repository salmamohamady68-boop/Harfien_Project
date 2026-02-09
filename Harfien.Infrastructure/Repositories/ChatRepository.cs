using Harfien.DataAccess;
using Harfien.Domain.Entities;
using Harfien.Domain.Interface_Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Harfien.Infrastructure.Repositories
{
    public class ChatRepository
        : GenericRepository<Chat>, IChatRepository
    {
        public ChatRepository(HarfienDbContext context)
            : base(context)
        {
        }

        public async Task<Chat?> GetChatBetweenUsersAsync(string user1Id, string user2Id)
        {
            return await _dbSet
                .Include(c => c.Messages)
                .FirstOrDefaultAsync(c =>
                    (c.User1Id == user1Id && c.User2Id == user2Id) ||
                    (c.User1Id == user2Id && c.User2Id == user1Id));
        }

        public async Task<IEnumerable<Chat>> GetUserChatsAsync(string userId)
        {
            return await _dbSet
                .Include(c => c.Messages)
                .Where(c => c.User1Id == userId || c.User2Id == userId)
                .ToListAsync();
        }
    }
}

