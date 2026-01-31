using Harfien.DataAccess;
using Harfien.Domain.Entities;
using Harfien.Domain.Shared.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harfien.Infrastructure.Repositories
{
    public class WalletTransactionRepository
    : GenericRepository<WalletTransaction>, IWalletTransactionRepository
    {
        public WalletTransactionRepository(HarfienDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<WalletTransaction>> GetByWalletIdAsync(int walletId)
        {
            return await _dbSet
                .Where(t => t.WalletId == walletId)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<WalletTransaction>> GetByOrderIdAsync(int orderId)
        {
            return await _dbSet
                .Where(t => t.OrderId == orderId)
                .ToListAsync();
        }
    }

}
