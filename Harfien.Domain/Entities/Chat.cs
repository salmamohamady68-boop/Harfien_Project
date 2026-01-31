using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harfien.Domain.Entities
{
   



        public class Chat
        {
            [Key]
            public int ChatId { get; set; }

            public int orderId { get; set; }


            public ICollection<ChatMessage> Messages { get; set; }
        }


    }



