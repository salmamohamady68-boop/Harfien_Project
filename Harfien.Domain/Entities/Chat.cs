using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Harfien.Domain.Entities
{
    public class Chat : BaseEntity
    {
        [Key]
        public int ChatId { get; set; }

        public int OrderId { get; set; }

        public string User1Id { get; set; }
        public string User2Id { get; set; }

        public ICollection<ChatMessage> Messages { get; set; } = new List<ChatMessage>();
    }
}





