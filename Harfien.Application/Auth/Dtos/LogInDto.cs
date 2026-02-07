using System.ComponentModel.DataAnnotations;

namespace Harfien.Application.Dtos.Auth
{
    public class loginDto
    {
        [Required(ErrorMessage = "the Username is required")]
        public string Identifier { get; set; } = null!;

        [Required(ErrorMessage = "the password is required")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "the password must be at least 6 characters long")]
        public string Password { get; set; } = null!;
    }
}
