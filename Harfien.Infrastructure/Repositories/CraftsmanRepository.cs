using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Harfien.DataAccess;
using Harfien.Domain.Entities;
using Harfien.Domain.Shared.Repositories;
using Microsoft.EntityFrameworkCore;
using Harfien.Domain.Interface_Repository.Repositories;


namespace Harfien.Infrastructure.Repositories
{
    public class CraftsmanRepository
     : GenericRepository<Craftsman>, ICraftsmanRepository
    {
        public CraftsmanRepository(HarfienDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Craftsman>> GetAllWithUserAsync()
        {
            return await _context.Craftsmen
                .Include(c => c.User)
                .ToListAsync();
        }

        public async Task<Craftsman?> GetByUserIdAsync(string userId)
        {
            return await _context.Craftsmen
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }

        public async Task UpdateAsync(Craftsman craftsman)
        {
            _context.Craftsmen.Update(craftsman);
            await _context.SaveChangesAsync();
        }

    }




}
