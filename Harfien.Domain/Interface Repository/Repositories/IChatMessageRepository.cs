using Harfien.Domain.Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harfien.Domain.Entities
{

        public interface IChatMessageRepository
            : IGenericRepository<ChatMessage>
        {
            Task<List<ChatMessage>> GetChatBetweenUsers(
                string user1Id,
                string user2Id
            );
        }
    }
