using Harfien.Domain.Entities;
using Harfien.Domain.Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harfien.Domain.Interfaces
{
    public interface IWalletRepository : IGenericRepository<Wallet>
    {
        Task<Wallet?> GetByUserIdAsync(string userId);
        Task<bool> HasSufficientBalanceAsync(string userId, decimal amount);
    }

}
