using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harfien.Application.DTO.Payment
{
    public class WithdrawRequestDto
    {
        [Required]
        [CreditCard(ErrorMessage = "Invalid card number format.")]
        public string? CardNumber { get; set; }
       
        [Required]
        [Range(1, 12, ErrorMessage = "Expiration month must be between 1 and 12.")]
        public long? ExpMonth { get; set; }
        [Required]
        [Range(2024, 2100, ErrorMessage = "Invalid expiration year.")]
        public long? ExpYear { get; set; }
        [Required]
        [RegularExpression(@"^\d{3,4}$", ErrorMessage = "CVC must be 3 or 4 digits.")]
        public string? Cvc { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        [Range(1, 100000, ErrorMessage = "Amount must be greater than 0")]
        public decimal Amount { get; set; }
    }
}
