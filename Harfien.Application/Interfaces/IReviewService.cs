using Harfien.Application.DTO.Review;
using Harfien.Domain.Shared;

namespace Harfien.Application.Interfaces
{
    public interface IReviewService
    {
        Task<GetReviewDto> AddReviewAsync(CreateReviewDto dto, String currentUserId);
        Task<IEnumerable<GetReviewDto>> GetReviewsByCraftsmanIdAsync(int craftsmanId);
        Task<PagedResult<GetReviewDto>> GetPagedReviewsByCraftsmanIdAsync(int craftsmanId, int pageNumber, int pageSize);
    }
}
