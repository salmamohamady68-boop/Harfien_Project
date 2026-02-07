using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Harfien.DataAccess;
using Harfien.Domain.Entities;
using Harfien.Domain.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Harfien.Infrastructure.Repositories
{
    public class CraftsmanRepository
     : GenericRepository<Craftsman>, ICraftsmanRepository
    {
        private readonly HarfienDbContext _context;

        public CraftsmanRepository(HarfienDbContext context) : base(context) {
            _context = context;
        }

        public async Task<IEnumerable<Craftsman>> GetAvailableByServiceAsync(int serviceId)
        {
            return await _context.Craftsmen
                .Include(c => c.CraftsmanServices)
                .Where(c => c.CraftsmanServices.Any(s => s.Id == serviceId))
                .ToListAsync();
        }

        public async Task<Craftsman?> GetWithServicesAsync(int craftsmanId)
        {
            return await _context.Craftsmen
                .Include(c => c.CraftsmanServices)
                .FirstOrDefaultAsync(c => c.Id == craftsmanId);
        }
        public async Task<Craftsman?> GetByUserIdAsync(string userId)
        {
            return await _context.Craftsmen
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }

   
        public async Task UpdateAsync(Craftsman craftsman)
        {
            _context.Craftsmen.Update(craftsman);
            await _context.SaveChangesAsync();
        }
    }

}
