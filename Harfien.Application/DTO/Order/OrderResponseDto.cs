using Harfien.Domain.Enums;
using System.Security.Cryptography.X509Certificates;

namespace Harfien.Application.DTO.Order
{
    public class OrderResponseDto
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string? UserId { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; } = null!;
        public string ClientName { get; set; } = null!;
        public string CraftsmanName { get; set; } = null!;
        public string Description { get; set; }
        public decimal Amount { get; set; }    

        public OrderStatus Status { get; set; }

        public DateTime ScheduledAt { get; set; }
        public int CraftsmanId { get; set; }
        
    }
}