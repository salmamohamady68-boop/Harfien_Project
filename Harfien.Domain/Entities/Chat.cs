<<<<<<< HEAD
﻿using System;
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



=======
﻿using System.ComponentModel.DataAnnotations;
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
>>>>>>> a58fe802e03bde75675fa60695467788172c18b2
