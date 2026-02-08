using Harfien.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Harfien.Application.Dtos
{
    public class RegisterModel
    {
        public string Fullname { get; set; } = string.Empty;
        public string Email { get; set; }
        public string Password { get; set; }
        public string phoneNumber { get; set; }
        public string Address { get; set; } = string.Empty;
        public string? Zone { get; set; }
        public int ? AreaId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Gender? Gender { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
