using Harfien.Application.DTO;
using Harfien.Application.Interfaces;
using Harfien.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Harfien.Application.Services
{
    public class ChatMessageService : IChatMessageService
    {
        private readonly IChatMessageRepository _repo;

        public ChatMessageService(IChatMessageRepository repo)
        {
            _repo = repo;
        }

        public async Task SendMessageAsync(AddChatMessageDto dto, string senderId)
        {
            var message = new ChatMessage
            {
                ChatId = dto.ChatId,
                SenderId = senderId,
                ReceiverId = dto.ReceiverId,
                MessageText = dto.Content,
                SentAt = DateTime.UtcNow
            };

            await _repo.AddAsync(message);
        }

        public async Task<object> GetMessagesByChatIdAsync(int chatId)
        {
            var allMessages = await _repo.GetAllAsync();
            return allMessages.Where(m => m.ChatId == chatId)
                              .OrderBy(m => m.SentAt)
                              .Select(m => new
                              {
                                  m.Id,
                                  m.ChatId,
                                  m.SenderId,
                                  m.ReceiverId,
                                  m.MessageText,
                                  m.SentAt,
                                  m.IsRead
                              });
        }
    }
}


