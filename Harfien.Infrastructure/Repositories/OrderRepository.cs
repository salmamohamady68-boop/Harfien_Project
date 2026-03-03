using Harfien.DataAccess;
using Harfien.Domain.Entities;
using Harfien.Domain.Enums;
using Harfien.Domain.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Harfien.Infrastructure.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(HarfienDbContext context) : base(context) { }

        // ==============================
        // Get Order By Id With Details
        // ==============================
        public async Task<Order?> GetByIdWithDetailsAsync(int id)
            => await _context.Orders
                .Include(o => o.Client)
                    .ThenInclude(c => c.User)
                .Include(o => o.Craftsman)
                    .ThenInclude(c => c.User)
                .Include(o => o.Service)
                .Include(o => o.Payment)
                .FirstOrDefaultAsync(o => o.Id == id);

        // ==============================
        // Get All Orders With Details
        // ==============================
        public async Task<IEnumerable<Order>> GetAllWithDetailsAsync()
            => await _context.Orders
                .Include(o => o.Client)
                    .ThenInclude(c => c.User)
                .Include(o => o.Craftsman)
                    .ThenInclude(c => c.User)
                .Include(o => o.Service)
                .Include(o => o.Payment)
                .ToListAsync();

        // ==============================
        // Get Orders By Client Id
        // ==============================
        public async Task<IEnumerable<Order>> GetByClientIdAsync(int clientId)
            => await _context.Orders
                .Include(o => o.Client)
                    .ThenInclude(c => c.User)
                .Include(o => o.Craftsman)
                    .ThenInclude(c => c.User)
                .Include(o => o.Service)
                .Include(o => o.Payment)
                .Where(o => o.ClientId == clientId)
                .ToListAsync();

        // ==============================
        // Get Orders By Craftsman Id
        // ==============================
        public async Task<IEnumerable<Order>> GetByCraftsmanIdAsync(int craftsmanId)
            => await _context.Orders
                .Include(o => o.Client)
                    .ThenInclude(c => c.User)
                .Include(o => o.Craftsman)
                    .ThenInclude(c => c.User)
                .Include(o => o.Service)
                .Include(o => o.Payment)
                .Where(o => o.CraftsmanId == craftsmanId)
                .ToListAsync();

        // ==============================
        // Get Orders By Status
        // ==============================
        public async Task<IEnumerable<Order>> GetByStatusAsync(OrderStatus status)
            => await _context.Orders
                .Include(o => o.Client)
                    .ThenInclude(c => c.User)
                .Include(o => o.Craftsman)
                    .ThenInclude(c => c.User)
                .Include(o => o.Service)
                .Include(o => o.Payment)
                .Where(o => o.Status == status)
                .ToListAsync();

        // ==============================
        // Check If Slot Exists
        // ==============================
        public async Task<bool> ExistsAsync(int craftsmanId, DateTime scheduledAt)
        {
            return await _dbSet.AnyAsync(o =>
                o.CraftsmanId == craftsmanId &&
                o.ScheduledAt == scheduledAt
            );
        }
    }
}
