using Harfien.DataAccess;
using Harfien.Domain.Entities;
using Harfien.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;


public class ChatMessageRepository : GenericRepository<ChatMessage>, IChatMessageRepository
{
    public ChatMessageRepository(HarfienDbContext context)
             : base(context)
    {
    }

    public async Task<List<ChatMessage>> GetChatBetweenUsers(
        string user1Id,
        string user2Id)
    {
        return await _dbSet
            .Where(m =>
                (m.SenderId == user1Id && m.ReceiverId == user2Id) ||
                (m.SenderId == user2Id && m.ReceiverId == user1Id))
            .OrderBy(m => m.SentAt)
            .ToListAsync();
    }
}
