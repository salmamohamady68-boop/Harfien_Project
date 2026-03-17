using Harfien.Application.DTO.Complaint;
using Harfien.Application.DTO.Order;
using Harfien.Application.Exceptions;
using Harfien.Application.Interfaces;
using Harfien.Domain.Entities;
using Harfien.Domain.Enums;
using Harfien.Domain.Shared.Repositories;

namespace Harfien.Application.Services
{
    public class ComplaintService : IComplaintService
    {
        private readonly IUnitOfWork _unit;

        public ComplaintService(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task<ComplaintResponseDto> CreateComplaintAsync(int reporterId, CreateComplaintDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Invalid complaint data");

            if (dto.OrderId <= 0)
                throw new BadRequestException("Invalid order id");

            var order = await _unit.Orders.GetByIdAsync(dto.OrderId);

            if (order == null)
                throw new NotFoundException("Order not found");

            var complaint = new Complaint
            {
                ReporterId = reporterId,
                OrderId = dto.OrderId,
                Description = dto.Description,
                EvidenceAttachmentUrl = dto.EvidenceAttachmentUrl,
                Status = ComplaintStatus.Pending,
                CreatedAt = DateTime.UtcNow
            };

            await _unit.ComplaintRepository.AddAsync(complaint);
            await _unit.SaveAsync();

            return new ComplaintResponseDto
            {
                Id = complaint.Id,
                clientId = complaint.ReporterId,
                craftsmanId = complaint.Order.CraftsmanId,
                Description = complaint.Description,
                EvidenceAttachmentUrl = complaint.EvidenceAttachmentUrl,
                Status = complaint.Status,
                CreatedAt = complaint.CreatedAt,
                OrderId = complaint.OrderId,
                ScheduledAt = order.ScheduledAt,
                OrderStatus = order.Status
            };
        }
        public async Task<ComplaintResponseDto> UpdateComplaintAsync(int reporterId, int complaintId, UpdateComplaintDto dto)
        {
            var complaint = await _unit.ComplaintRepository.GetWithOrderAsync(complaintId);

            if (complaint == null)
                throw new NotFoundException("Complaint not found");

            if (complaint.ReporterId != reporterId)
                throw new BadRequestException("You are not allowed to update this complaint");

            if (complaint.Status != ComplaintStatus.Pending)
                throw new BadRequestException("Only pending complaints can be updated");

            complaint.Description = dto.Description;
            complaint.EvidenceAttachmentUrl = dto.EvidenceAttachmentUrl;

            await _unit.SaveAsync();

            return new ComplaintResponseDto
            {
                Id = complaint.Id,
                clientId = complaint.ReporterId,
                craftsmanId = complaint.Order.CraftsmanId,
                Description = complaint.Description,
                EvidenceAttachmentUrl = complaint.EvidenceAttachmentUrl,
                Status = complaint.Status,
                CreatedAt = complaint.CreatedAt,
                AdminResolutionNotes = complaint.AdminResolutionNotes,
                OrderId = complaint.OrderId,
                ScheduledAt = complaint.Order.ScheduledAt,
                OrderStatus = complaint.Order.Status
            };
        }

        public async Task<ComplaintResponseDto> DeleteComplaintAsync(int reporterId, int complaintId)
        {
            var complaint = await _unit.ComplaintRepository.GetWithOrderAsync(complaintId);

            if (complaint == null)
                throw new NotFoundException("Complaint not found");

            if (complaint.ReporterId != reporterId)
                throw new BadRequestException("You are not allowed to delete this complaint");

            if (complaint.Status != ComplaintStatus.Pending)
                throw new BadRequestException("Only pending complaints can be deleted");

            var response = new ComplaintResponseDto
            {
                Id = complaint.Id,
                clientId = complaint.ReporterId,
                craftsmanId = complaint.Order.CraftsmanId,
                Description = complaint.Description,
                EvidenceAttachmentUrl = complaint.EvidenceAttachmentUrl,
                Status = complaint.Status,
                CreatedAt = complaint.CreatedAt,
                OrderId = complaint.OrderId,
                ScheduledAt = complaint.Order.ScheduledAt,
                OrderStatus = complaint.Order.Status
            };

            _unit.ComplaintRepository.Delete(complaint);
            await _unit.SaveAsync();

            return response;
        }

        

        public async Task<IEnumerable<ComplaintResponseDto>> GetMyComplaintsAsync(int reporterId)
        {
            var complaints = await _unit.ComplaintRepository.GetByReporterIdAsync(reporterId);

            return complaints.Select(c => new ComplaintResponseDto  {
                Id = c.Id,
                clientId = c.ReporterId,
                craftsmanId = c.Order.CraftsmanId,
                Description = c.Description,
                EvidenceAttachmentUrl = c.EvidenceAttachmentUrl,
                Status = c.Status,
                CreatedAt = c.CreatedAt,
                AdminResolutionNotes = c.AdminResolutionNotes,
                OrderId = c.OrderId,
                ScheduledAt = c.Order.ScheduledAt,
                OrderStatus = c.Order.Status
            });
        }

        public async Task<IEnumerable<ComplaintResponseDto>> GetComplaintsIssuedForCraftsmanAsync(int craftsmanId)
        {
            var complaints = await _unit.ComplaintRepository.GetByCraftsmanIdAsync(craftsmanId);

            return complaints.Select(c => new ComplaintResponseDto
            {
                Id = c.Id,
                clientId = c.ReporterId,
                craftsmanId = craftsmanId,
                Description = c.Description,
                EvidenceAttachmentUrl = c.EvidenceAttachmentUrl,
                Status = c.Status,
                CreatedAt = c.CreatedAt,
                AdminResolutionNotes = c.AdminResolutionNotes,
                OrderId = c.OrderId,
                ScheduledAt = c.Order.ScheduledAt,
                OrderStatus = c.Order.Status
            });
        }

        public async Task<ComplaintResponseDto?> GetComplaintByIdAsync(int userId, int complaintId)
        {
            var c = await _unit.ComplaintRepository.GetWithOrderAsync(complaintId);

            if (c?.ReporterId != userId && c?.Order?.CraftsmanId != userId)
                return null;

            return new ComplaintResponseDto
            {
                Id = c.Id,
                clientId = c.ReporterId,
                craftsmanId = c.Order.CraftsmanId,
                Description = c.Description,
                EvidenceAttachmentUrl = c.EvidenceAttachmentUrl,
                Status = c.Status,
                CreatedAt = c.CreatedAt,
                AdminResolutionNotes= c.AdminResolutionNotes,
                OrderId = c.OrderId,
                ScheduledAt = c.Order.ScheduledAt,
                OrderStatus = c.Order.Status
            };
        }

        // Admin
        public async Task<IEnumerable<ComplaintDetailsDto>> GetAllComplaintsAsync()
        {
            var complaints = await _unit.ComplaintRepository.GetAllWithOrdersAsync();

            return complaints.Select(c => new ComplaintDetailsDto
            {
                Id = c.Id,
                Description = c.Description,
                EvidenceAttachmentUrl = c.EvidenceAttachmentUrl,
                Status = c.Status,
                AdminResolutionNotes = c.AdminResolutionNotes,
                ResolvedAt = c.ResolvedAt,
               
                Order = new OrderInfoDto
                {
                    OrderId = c.Order.Id,
                    ClientName = c.Order.Client.User.FullName,
                    CraftsmanName = c.Order.Craftsman.User.FullName,
                    ServiceName = c.Order.Service.Name,
                    ScheduledAt = c.Order.ScheduledAt,
                    OrderStatus = c.Order.Status,
                    Amount = c.Order.Amount
                }
            });
        }

        public async Task<ComplaintDetailsDto?> GetComplaintDetailsAsync(int complaintId)
        {
            var c = await _unit.ComplaintRepository.GetWithOrderAsync(complaintId);

            if (c == null) return null;

            return new ComplaintDetailsDto
            {
                Id = c.Id,
                Description = c.Description,
                EvidenceAttachmentUrl = c.EvidenceAttachmentUrl,
                Status = c.Status,
                AdminResolutionNotes = c.AdminResolutionNotes,
                ResolvedAt = c.ResolvedAt,

                Order = new OrderInfoDto
                {
                    OrderId = c.Order.Id,
                    ClientName = c.Order.Client.User.FullName,
                    CraftsmanName = c.Order.Craftsman.User.FullName,
                    ServiceName = c.Order.Service.Name,
                    ScheduledAt = c.Order.ScheduledAt,
                    OrderStatus = c.Order.Status,
                    Amount = c.Order.Amount
                }
            };
        }



        public async Task<ComplaintResponseDto> ChangeStatusAsync(int complaintId, ComplaintStatus status)
        {
            var complaint = await _unit.ComplaintRepository.GetWithOrderAsync(complaintId);

            if (complaint == null)
                throw new NotFoundException("Complaint not found");

            complaint.Status = status;
            await _unit.SaveAsync();

            return new ComplaintResponseDto
            {
                Id = complaint.Id,
                clientId = complaint.ReporterId,
                craftsmanId = complaint.Order.CraftsmanId,
                Description = complaint.Description,
                EvidenceAttachmentUrl = complaint.EvidenceAttachmentUrl,
                Status = complaint.Status,
                CreatedAt = complaint.CreatedAt,
                OrderId = complaint.OrderId,
                ScheduledAt = complaint.Order.ScheduledAt,
                OrderStatus = complaint.Order.Status
            };
        }

        public async Task<ComplaintResponseDto> AddResolutionAsync(int complaintId, string notes)
        {
            var complaint = await _unit.ComplaintRepository.GetWithOrderAsync(complaintId);

            if (complaint == null)
                throw new NotFoundException("Complaint not found");

            complaint.AdminResolutionNotes = notes;
            complaint.ResolvedAt = DateTime.UtcNow;
            complaint.Status = ComplaintStatus.Resolved;

            await _unit.SaveAsync();

            return new ComplaintResponseDto
            {
                Id = complaint.Id,
                clientId = complaint.ReporterId,
                craftsmanId = complaint.Order.CraftsmanId,
                Description = complaint.Description,
                EvidenceAttachmentUrl = complaint.EvidenceAttachmentUrl,
                Status = complaint.Status,
                CreatedAt = complaint.CreatedAt,
                AdminResolutionNotes = complaint.AdminResolutionNotes,
                OrderId = complaint.OrderId,
                ScheduledAt = complaint.Order.ScheduledAt,
                OrderStatus = complaint.Order.Status
            };
        }




    }
}
