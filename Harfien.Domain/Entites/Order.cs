using Harfien.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harfien.Domain.Entites
{
    public class Order : BaseEntity
    {
        public OrderStatus Status { get; set; }

        public Guid ServiceId { get; set; }   // FK
        public Guid UserId { get; set; }      // FK

        // Navigation
        public Payment? Payment { get; set; }
    }
}
