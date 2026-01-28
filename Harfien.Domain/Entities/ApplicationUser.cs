using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Harfien.Domain.Enums;
using Microsoft.AspNetCore.Identity;
 namespace Harfien.Domain.Entities
{
    public class ApplicationUser:IdentityUser
    {

        public string FullName { get; set; }=string.Empty;
        public string Address { get; set; } = string.Empty;

        public string? Zone { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Gender? Gender { get; set; }
        public string? ProfileImage { get; set; }
        public DateTime? CreatedAt { get; set; }
        public decimal WalletBalance { get; set; } = 0;
        public bool IsActive { get; set; } = true;



     
    }
}
