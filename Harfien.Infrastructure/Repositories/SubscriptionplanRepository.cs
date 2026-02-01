using Harfien.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harfien.Infrastructure.Repositories
{
    public class SubscriptionPlanRepository
        : GenericRepository<SubscriptionPlan>, ISubscriptionPlanRepository
    {
        public SubscriptionPlanRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<SubscriptionPlan>> GetAllWithDetailsAsync()
        {
            return await _dbSet
                .Include(p => p.Details)   // Eager Loading
                .ToListAsync();
        }

        public async Task<SubscriptionPlan?> GetByIdWithDetailsAsync(int id)
        {
            return await _dbSet
                .Include(p => p.Details)   // Eager Loading
                .FirstOrDefaultAsync(p => p.Id == id);
        }


    }
}
