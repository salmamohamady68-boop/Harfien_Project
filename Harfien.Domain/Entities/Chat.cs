using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTrainer.Models
{


    public class Chat
    {
        [Key]
        public int ChatId { get; set; }

        public int orderId { get; set; }
        public Order Order { get; set; }

        public ICollection<ChatMessage> Messages { get; set; }
    }


}