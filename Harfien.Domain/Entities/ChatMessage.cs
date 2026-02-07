
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harfien.Domain.Entities
{
    public class ChatMessage:BaseEntity
    {

       
        public string MessageText { get; set; }

        public string SenderId { get; set; }
        public ApplicationUser Sender { get; set; }

        // Foreign Key
       [ForeignKey("ChatId")]
        public int ChatId { get; set; }
        public Chat Chat { get; set; }
        public DateTime SentAt { get; set; } = DateTime.UtcNow;

        public bool IsRead { get; set; } = false;

    }
}