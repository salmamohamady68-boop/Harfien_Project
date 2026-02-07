using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harfien.Application.DTO
{
    public class ConfirmPasswordDto
    {
        [Required]
        public string Password { get; set; }
       
    }
}
