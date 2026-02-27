using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harfien.Application.Autherization
{
    public class LoginResponse
    {

        public bool Success { get; set; }
        public string? Token { get; set; }
        public string? Message { get; set; }
        public string? UserId { get; set; }
        public string? Role { get; set; }
        public int? CraftsmanId { get; set; }
        public int? ClientId { get; set; }

    }
}
