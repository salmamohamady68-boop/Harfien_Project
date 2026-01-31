using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harfien.Domain.Entities
{
    public class CraftsmanAvailability
    {
        public int Id { get; set; }

        public int CraftsmanId { get; set; }
        public Craftsman Craftsman { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public TimeSpan From { get; set; }
        public TimeSpan To { get; set; }

        public bool IsAvailable { get; set; } = true;
    }

}
