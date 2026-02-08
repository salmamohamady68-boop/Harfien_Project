using Harfien.DataAccess;
using Harfien.Domain.Entities;
using Harfien.Domain.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Harfien.Infrastructure.Repositories
{
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        public ReviewRepository(HarfienDbContext context) : base(context) { }
        public async Task<List<Review>> GetAllByCraftsmanIdAsync(int craftsmanId)
        {
            return await _dbSet
                .Include(r => r.Order)
                    .ThenInclude(o => o.Client)
                        .ThenInclude(c => c.User)
                .Where(r => r.CraftsmanId == craftsmanId)
                .ToListAsync();
        }
    }
}