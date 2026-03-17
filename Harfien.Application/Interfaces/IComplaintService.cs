using Harfien.Application.DTO.Complaint;
using Harfien.Domain.Entities;
using Harfien.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harfien.Application.Interfaces
{
    public interface IComplaintService
    {
        Task<ComplaintResponseDto> CreateComplaintAsync(int reporterId, CreateComplaintDto dto);
        Task<ComplaintResponseDto> UpdateComplaintAsync(int reporterId, int complaintId, UpdateComplaintDto dto);
        Task<ComplaintResponseDto> DeleteComplaintAsync(int reporterId, int complaintId);

        Task<IEnumerable<ComplaintResponseDto>> GetMyComplaintsAsync(int reporterId);
        Task<ComplaintResponseDto?> GetComplaintByIdAsync(int userId, int complaintId);

        Task<IEnumerable<ComplaintDetailsDto>> GetAllComplaintsAsync(); // Admin
        Task<ComplaintDetailsDto?> GetComplaintDetailsAsync(int complaintId); // Admin
        Task<ComplaintResponseDto> ChangeStatusAsync(int complaintId, ComplaintStatus status);//admin
        Task<ComplaintResponseDto> AddResolutionAsync(int complaintId, string notes); //admin
        Task<IEnumerable<ComplaintResponseDto>> GetComplaintsIssuedForCraftsmanAsync(int craftsmanId);
    }

}
