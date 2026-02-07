using Harfien.DataAccess;
using Harfien.Domain.Entities;
using Harfien.Domain.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Harfien.Infrastructure.Repositories
{
    public class ServiceRepository : GenericRepository<Service>, IServiceRepository
    {
        public ServiceRepository(HarfienDbContext context) : base(context) { }

      


        public async Task<List<Service>> GetAllServicesWithCraftData()
        {
            return await _dbSet
                 .Include(s => s.Craftsman)
                 .Include(s => s.ServiceCategory)
                 .ToListAsync();
        }

        public async Task<Service?> GetServiceByIdWithCraftData(int id)
        {
              return await _dbSet
                    .Include(s => s.Craftsman)
                    .Include(s => s.ServiceCategory)
                    .FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}