using Harfien.Application.DTO;

namespace Harfien.Application.Interfaces
{
    public interface IReviewService
    {
        Task<ReviewDto> AddReviewAsync(CreateReviewDto dto, String currentUserId);
        Task<List<ReviewDto>> GetReviewsByCraftsmanIdAsync(int craftsmanId);
    }
}
