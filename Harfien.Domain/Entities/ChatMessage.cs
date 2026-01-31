<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harfien.Domain.Entities
{
    public class ChatMessage
    {

        [Key] // Primary Key
        public int MessageId { get; set; }


        public string MessageText { get; set; }

        public int SenderId { get; set; }

        // Foreign Key
        public int ChatId { get; set; }

        [ForeignKey("ChatId")]
        public Chat Chat { get; set; }

    }
=======
﻿using ProjectTrainer.Models;
using System.ComponentModel.DataAnnotations;

public class ChatMessage
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string MessageText { get; set; }

    [Required]
    public string SenderId { get; set; }
    public ApplicationUser Sender { get; set; }

    public int ChatId { get; set; }
    public Chat Chat { get; set; }

    public DateTime SentAt { get; set; } = DateTime.UtcNow;

    public bool IsRead { get; set; } = false;
>>>>>>> a58fe802e03bde75675fa60695467788172c18b2
}
