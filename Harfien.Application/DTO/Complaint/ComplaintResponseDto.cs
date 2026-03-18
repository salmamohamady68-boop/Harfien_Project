using Harfien.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harfien.Application.DTO.Complaint
{
    public class ComplaintResponseDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int CraftsmanId { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ServiceName { get; set; }
        public string ServiceCategoryName { get; set; }
        public string Description { get; set; }
        public string? EvidenceAttachmentUrl { get; set; }
        public ComplaintStatus Status { get; set; }
        public string? AdminResolutionNotes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ScheduledAt { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }

}
