using Harfien.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harfien.Application.DTO
{
    public class UpdateOrderDto
    {
        public string Description { get; set; } = null!;
        public DateTime ScheduledAt { get; set; }
        public OrderStatus Status { get; set; }
        public decimal Amount { get; set; }
    }
}
