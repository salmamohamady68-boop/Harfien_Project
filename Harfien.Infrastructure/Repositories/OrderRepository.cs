using Harfien.DataAccess;
using Harfien.Domain.Entities;
using Harfien.Domain.Enums;
using Harfien.Domain.Shared.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harfien.Infrastructure.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(HarfienDbContext context) : base(context) { }

        public async Task<Order?> GetByIdWithDetailsAsync(int id)
        {
            return await _dbSet
                .Include(o => o.Client)
                .Include(o => o.Craftsman)
                .Include(o => o.Service)
                .Include(o => o.Payment)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<IEnumerable<Order>> GetByClientIdAsync(int clientId)
        {
            return await _dbSet
                .Include(o => o.Craftsman)
                .Include(o => o.Service)
                .Include(o => o.Payment)
                .Where(o => o.ClientId == clientId)
                .OrderByDescending(o => o.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetByCraftsmanIdAsync(int craftsmanId)
        {
            return await _dbSet
                .Include(o => o.Client)
                .Include(o => o.Service)
                .Include(o => o.Payment)
                .Where(o => o.CraftsmanId == craftsmanId)
                .OrderByDescending(o => o.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetByStatusAsync(OrderStatus status)
        {
            return await _dbSet
                .Include(o => o.Client)
                .Include(o => o.Craftsman)
                .Include(o => o.Payment)
                .Where(o => o.Status == status)
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetAllWithDetailsAsync()
        {
            return await _dbSet
                .Include(o => o.Client)
                .Include(o => o.Craftsman)
                .Include(o => o.Service)
                .Include(o => o.Payment)
                .OrderByDescending(o => o.Id)
                .ToListAsync();
        }

        public async Task<bool> IsOrderBelongsToClientAsync(int orderId, int clientId)
        {
            return await _dbSet
                .AnyAsync(o => o.Id == orderId && o.ClientId == clientId);
        }
    }
}
