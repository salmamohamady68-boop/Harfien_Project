using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harfien.Domain.Entities
{
    public class SubscriptionPlan
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int DurationInDays { get; set; }

        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
