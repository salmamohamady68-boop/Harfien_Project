
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harfien.Domain.Entities
{
   



        public class Chat:BaseEntity
        {
            [Key]
            public int ChatId { get; set; }

            public int orderId { get; set; }

        public string User1Id { get; set; }
        public string User2Id { get; set; }
        public ICollection<ChatMessage> Messages { get; set; }
        }


    }



