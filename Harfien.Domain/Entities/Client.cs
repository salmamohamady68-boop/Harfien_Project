using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Harfien.Domain.Entites;

namespace Harfien.Domain.Entities
{
    public class Client
    {
        public int Id { get; set; }


        [ForeignKey(nameof(UserId))]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; } 

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Order> Orders { get; set; }
        public ICollection<SubscriptionPlanDetails> Subscriptions { get; set; }
    }
}
