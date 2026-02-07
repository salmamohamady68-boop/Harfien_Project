using Harfien.Domain.Entities;

namespace Harfien.Domain.Shared.Repositories
{
    public interface IReviewRepository : IGenericRepository<Review>
    {
        Task<List<Review>> GetAllByCraftsmanIdAsync(int craftsmanId);
    }
}