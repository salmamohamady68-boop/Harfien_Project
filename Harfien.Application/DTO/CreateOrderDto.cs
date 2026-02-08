using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harfien.Application.DTO
{
    public class CreateOrderDto
    {
        public int ServiceId { get; set; }
        public int CraftsmanId { get; set; }
        public string Description { get; set; } = null!;
        public DateTime ScheduledAt { get; set; }
    }
}
