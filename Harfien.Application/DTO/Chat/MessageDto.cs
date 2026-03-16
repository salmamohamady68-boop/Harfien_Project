using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harfien.Application.DTO.Chat
{
    public class MessageDto
    {
        public int Id { get; set; }

        public string SenderId { get; set; }
        public string SenderName { get; set; }
        public string SenderImage { get; set; }

        public string ReceiverId { get; set; }
        public string ReceiverName { get; set; }

        public string Content { get; set; }

        public DateTime SentAt { get; set; }

        public bool IsRead { get; set; }
        public string? SenderUsername { get; internal set; }
        public Domain.Entities.Area? SenderArea { get; internal set; }
        public string? ReceiverUsername { get; internal set; }
        public Domain.Entities.Area? ReceiverArea { get; internal set; }
    }
}
