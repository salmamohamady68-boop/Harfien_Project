using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harfien.Domain.Entities
{
    public class Subscription
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public int SubscriptionPlanId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string Status { get; set; }

        public User User { get; set; }
        public SubscriptionPlan SubscriptionPlan { get; set; }
    }
}
