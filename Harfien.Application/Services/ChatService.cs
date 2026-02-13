using Harfien.Application.DTO;
using Harfien.Application.Interfaces;
using Harfien.Domain.Entities;
using Harfien.Domain.Interface_Repository;
using System.Linq;
using System.Threading.Tasks;

namespace Harfien.Application.Services
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepo;

        public ChatService(IChatRepository chatRepo)
        {
            _chatRepo = chatRepo;
        }

        public async Task<int> CreateChatAsync(AddChatDto dto, string senderId)
        {
            // تحقق إذا كان الشات موجود
            var existingChat = await _chatRepo.GetChatBetweenUsersAsync(senderId, dto.ReceiverId);
            if (existingChat != null)
                return existingChat.ChatId;

            var chat = new Chat
            {
                OrderId = dto.OrderId,
                User1Id = senderId,
                User2Id = dto.ReceiverId
            };

            await _chatRepo.AddAsync(chat);
            return chat.ChatId;
        }

        public async Task<object> GetByOrderIdAsync(int orderId)
        {
            var chats = await _chatRepo.GetAllAsync();
            return chats.Where(c => c.OrderId == orderId);
        }
    }
}


