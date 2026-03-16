using Harfien.Application.DTO.Chat;
using Harfien.Application.Interfaces;
using Harfien.Domain.Entities;
using Harfien.Domain.Interface_Repository.Repositories;
using Harfien.Domain.Shared;

namespace Harfien.Application.Services
{
    public class ChatService : IChatService
    {
        private readonly IMessageRepositry _repository;
        private readonly IChatNotifier _notifier;

        public ChatService(IMessageRepositry repository,
                              IChatNotifier notifier)
        {
            _repository = repository;
            _notifier = notifier;
        }

        public async Task<MessageDto> SendMessageAsync(string senderId, SendMessageRequest dto)
        {
            var message = new ChatMessage
            {
                SenderId = senderId,
                ReceiverId = dto.ReceiverId,
                Content = dto.Content
            };

            await _repository.AddAsync(message);
            await _repository.SaveChangesAsync();

            var messageDto = new MessageDto
            {
                Id = message.Id,

                SenderId = message.SenderId,
                SenderName = message.Sender.FullName,
                SenderImage = message.Sender.ProfileImage,
                SenderUsername = message.Sender.UserName,
                SenderArea = message.Sender.Area,
                ReceiverId = message.ReceiverId,
                ReceiverName = message.Receiver.FullName,
                ReceiverUsername = message.Receiver.UserName,
                ReceiverArea = message.Receiver.Area,

                Content = message.Content,
                SentAt = message.SentAt,
                IsRead = message.IsRead
            };

            await _notifier.NotifyAsync(dto.ReceiverId, messageDto);

            return messageDto;
        }

        public async Task<List<MessageDto>> GetConversationAsync(string user1, string user2)
        {
            var messages = await _repository.GetConversationAsync(user1, user2);

            return messages.Select(m => new MessageDto
            {
                SenderId = m.SenderId,
                SenderName = m.Sender.FullName,
                SenderUsername = m.Sender.UserName,
                SenderImage = m.Sender.ProfileImage,
                SenderArea = m.Sender.Area,

                ReceiverId = m.ReceiverId,
                ReceiverName = m.Receiver.FullName,
                ReceiverUsername = m.Receiver.UserName,
                ReceiverArea = m.Receiver.Area,


                Content = m.Content,
                SentAt = m.SentAt
            }).ToList();
        }


        public async Task<List<ChatListDto>> GetChatListAsync(string currentUserId)
        {
            return await _repository.GetChatListAsync(currentUserId);
        }

        public async Task MarkAsReadAsync(string senderId, string receiverId)
        {
            await _repository.MarkAsReadAsync(senderId, receiverId);
        }

        public async Task<List<ChatUserDto>> GetAvailableUsersAsync(string currentUserId)
        {
            return await _repository.GetAvailableUsersAsync(currentUserId);
        }




    }
}