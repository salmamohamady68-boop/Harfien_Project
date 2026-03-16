using Harfien.DataAccess;
using Harfien.Domain.Entities;
using Harfien.Domain.Interface_Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using Harfien.Domain.Shared;
using Harfien.Application.DTO.Chat;


namespace Harfien.Infrastructure.Repositories
{
    public class MessageRepositry : IMessageRepositry
    {
        private readonly HarfienDbContext _context;

        public MessageRepositry(HarfienDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ChatMessage message)
        {
            await _context.ChatMessages.AddAsync(message);
        }

        public async Task<List<ChatMessage>> GetConversationAsync(string user1, string user2)
        {
            return await _context.ChatMessages
                .Where(m =>
                    (m.SenderId == user1 && m.ReceiverId == user2) ||
                    (m.SenderId == user2 && m.ReceiverId == user1))
                .OrderBy(m => m.SentAt).Include(m=>m.Sender).Include(m=>m.Receiver)
                .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }


        public async Task<List<ChatListDto>> GetChatListAsync(string currentUserId)
        {
            var messages = await _context.ChatMessages
                .Include(m => m.Sender)
                .Include(m => m.Receiver)
                .Where(m => m.SenderId == currentUserId || m.ReceiverId == currentUserId)
                .ToListAsync();

            var chatList = messages
                .GroupBy(m => m.SenderId == currentUserId ? m.ReceiverId : m.SenderId)
                .Select(g =>
                {
                    var lastMessage = g.OrderByDescending(x => x.SentAt).First();

                    var otherUser = lastMessage.SenderId == currentUserId
                        ? lastMessage.Receiver
                        : lastMessage.Sender;

                    return new ChatListDto
                    {
                        UserId = otherUser.Id,
                        UserName = otherUser.FullName,
                        UserImage = otherUser.ProfileImage,

                        LastMessage = lastMessage.Content,
                        LastMessageTime = lastMessage.SentAt,

                        UnreadCount = g.Count(x =>
                            x.ReceiverId == currentUserId && !x.IsRead)
                    };
                })
                .OrderByDescending(x => x.LastMessageTime)
                .ToList();

            return chatList;
        }

        public async Task MarkAsReadAsync(string senderId, string receiverId)
        {
            var unreadMessages = await _context.ChatMessages
                .Where(m =>
                    m.SenderId == senderId &&
                    m.ReceiverId == receiverId &&
                    !m.IsRead)
                .ToListAsync();

            foreach (var msg in unreadMessages)
                msg.IsRead = true;

            await _context.SaveChangesAsync();
        }

        public async Task<List<ChatUserDto>> GetAvailableUsersAsync(string currentUserId)
        {
            return await _context.Users
                .Where(u => u.Id != currentUserId)
                .Select(u => new ChatUserDto
                {
                    UserId = u.Id,
                    UserName = u.UserName,
                    UserImage = u.ProfileImage,
                    IsOnline = false
                })
                .ToListAsync();
        }

    }
}
