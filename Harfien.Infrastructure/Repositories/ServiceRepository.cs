using Harfien.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harfien.Infrastructure.Repositories
{
    public class ServiceRepository
       : GenericRepository<Service>, IServiceRepository
    {
        public ServiceRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Service>> GetAllWithCraftsmanAsync()
        {
            return await _dbSet
                .Include(s => s.Craftsman)
                .ToListAsync();
        }
    }

}