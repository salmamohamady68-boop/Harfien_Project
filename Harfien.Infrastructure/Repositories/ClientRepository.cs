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
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        private readonly HarfienDbContext _context;

        public ClientRepository(HarfienDbContext context)  : base(context)
        {
            _context = context;
        }

        public async Task<List<Client>> GetAllWithIncludesAsync()
        {
            return await _context.Clients
                .Include(c => c.User)
                .Include(c => c.Orders)
                .Include(c => c.Subscriptions)
                .ToListAsync();
        }

        public async Task<Client?> GetByIdWithIncludesAsync(int id)
        {
            return await _context.Clients
                .Include(c => c.User)
                .Include(c => c.Orders)
                .Include(c => c.Subscriptions)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task DeleteAsync(Client client)
        {
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Client?> GetClientWithOrdersAsync(int clientId)
        {
            return await _context.Clients
                .Include(c => c.Orders)
                .FirstOrDefaultAsync(c => c.Id == clientId);
        }

        public async Task<Client?> GetByUserIdAsync(string userId)
        {
            return await _context.Clients
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }
        public async Task<List<Client>> SearchAsync(string keyword)
        {
            return await _context.Clients
                .Include(c => c.User)
                .Include(c => c.Orders)
                .Include(c => c.Subscriptions)
                .Where(c => c.User.FullName.Contains(keyword))
                .ToListAsync();
        }
    }
}
