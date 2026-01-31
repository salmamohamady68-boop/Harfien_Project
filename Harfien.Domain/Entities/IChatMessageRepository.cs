using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harfien.Domain.Entities
{

    public class ChatMessageRepository
    : GenericRepository<ChatMessage>, IChatMessageRepository
    {
        public ChatMessageRepository(HarfienDbContext context)
            : base(context)
        {
        }

       
    }
}