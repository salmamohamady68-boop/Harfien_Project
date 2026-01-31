using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading.Tasks;
using Harfien.Domain.Entities;   



namespace Harfien.Domain.Entities
{
    internal class ChatMessageRepository : IChatMessageRepository
    {
        private readonly List<ChatMessage> _messages;

        public ChatMessageRepository()
        {
            _messages = new List<ChatMessage>();
        }

        public Task<IEnumerable<ChatMessage>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<ChatMessage>>(_messages);
        }

        public Task<ChatMessage?> GetByIdAsync(int id)
        {
            var message = _messages.FirstOrDefault(m => m.MessageId == id);
            return Task.FromResult(message);
        }

        public Task InsertAsync(ChatMessage message)
        {
            _messages.Add(message);
            return Task.CompletedTask;
        }

        public void Update(ChatMessage message)
        {
            var existing = _messages.FirstOrDefault(m => m.MessageId == message.MessageId);
            if (existing != null)
            {
                existing.MessageText = message.MessageText;
            }
        }

        public Task DeleteAsync(int id)
        {
            var existing = _messages.FirstOrDefault(m => m.MessageId == id);
            if (existing != null)
                _messages.Remove(existing);
            return Task.CompletedTask;
        }
    }



}
