using Harfien.Domain.Enums;


namespace Harfien.Application.DTOs
{
    public class OrderResponseDto
    {
        public int Id { get; set; }
        public string ServiceName { get; set; } = null!;
        public string ClientName { get; set; } = null!;
        public string CraftsmanName { get; set; } = null!;
        public decimal Amount { get; set; }
        public OrderStatus Status { get; set; }
        public int CraftsmanId { get; set; }
        public int ClientId { get; set; }
    }

}
