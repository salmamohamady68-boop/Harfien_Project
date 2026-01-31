using System;
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
}
