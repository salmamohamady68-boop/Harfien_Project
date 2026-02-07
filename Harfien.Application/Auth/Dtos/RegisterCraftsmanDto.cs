using System.ComponentModel.DataAnnotations;

namespace Harfien.Application.Dtos.Auth
{
    public class RegisterCraftsmanDto
    {
        [Required(ErrorMessage = "the name is required")]
        public string FullName { get; set; } = null!;

        [Required(ErrorMessage = "the Phone is required")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(50, MinimumLength = 11, ErrorMessage = "the phonenumber must be at least 12 characters long")]
        public string PhoneNumber { get; set; } = null!;

        [Required(ErrorMessage = "the password is required")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "the password must be at least 6 characters long")]
        public string Password { get; set; } = null!;

        public int CityId { get; set; }

        public List<int> ServiceCategoryId { get; set; } = new List<int>();

        public int YearsOfExperience { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "You must agree to terms")]
        public bool AgreeTerms { get; set; }
    }
}
