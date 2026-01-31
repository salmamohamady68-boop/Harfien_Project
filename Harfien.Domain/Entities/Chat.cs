using Harfien.Domain.Entites;
using Harfien.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTrainer.Models
{


    public class Chat:BaseEntity
    {
        [Key]
        

        public int orderId { get; set; }
        public Order Order { get; set; }

        public ICollection<ChatMessage> Messages { get; set; }
    }


}