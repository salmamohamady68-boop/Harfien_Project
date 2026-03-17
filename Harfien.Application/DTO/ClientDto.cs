using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harfien.Application.DTO
{
    public  class ClientDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public List<int> OrdersIds { get; set; } = new();
        public List<int> SubscriptionIds { get; set; } = new();
        public string? Phone { get; internal set; }
        public bool IsActive { get; set; }
        public IFormFile? ProfilePicture { get; set; }
    }
}
