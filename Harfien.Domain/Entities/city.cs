using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harfien.Domain.Entities
{
    public class city
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GovernorateId { get; set; }
        public Governorate Governorate { get; set; }
    }
}
