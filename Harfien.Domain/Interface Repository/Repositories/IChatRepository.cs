using Harfien.Domain.Entities;
using Harfien.Domain.Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Harfien.Domain.Interface_Repository
{
 
    public interface IChatRepository : IGenericRepository<Chat>
    {
        Task<Chat?> GetChatBetweenUsersAsync(string user1Id, string user2Id);
        Task<IEnumerable<Chat>> GetUserChatsAsync(string userId);
    }
}




