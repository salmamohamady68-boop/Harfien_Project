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
    public class WalletRepository
    : GenericRepository<Wallet>, IWalletRepository
    {
        public WalletRepository(HarfienDbContext context)
            : base(context)
        {
        }

        public async Task<Wallet?> GetByUserIdAsync(string userId)
        {
            return await _dbSet
                .Include(w => w.Transactions)
                .FirstOrDefaultAsync(w => w.UserId == userId);
        }

        public async Task<bool> HasSufficientBalanceAsync(string userId, decimal amount)
        {
            var wallet = await _dbSet
                .FirstOrDefaultAsync(w => w.UserId == userId);

            if (wallet == null) return false;

            return wallet.Balance >= amount;
        }
    }

}
