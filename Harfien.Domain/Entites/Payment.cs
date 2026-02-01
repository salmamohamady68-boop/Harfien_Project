

using Harfien.Domain.Enums;

namespace Harfien.Domain.Entites
{
    public class Payment
    {
        public DateTime PaymentDate { get; set; }

        public decimal Amount { get; set; }

        public PaymentStatus Status { get; set; }

        public Guid OrderId { get; set; }   // FK

        // Navigation
        public Order Order { get; set; }
    }
}
