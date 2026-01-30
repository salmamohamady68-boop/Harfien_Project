using Harfien.Domain.Entities;
using Harfien.Domain.Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harfien.Domain.Interfaces
{
    public interface IWalletTransactionRepository
      : IGenericRepository<WalletTransaction>
    {
        Task<IEnumerable<WalletTransaction>> GetByWalletIdAsync(int walletId);
        Task<IEnumerable<WalletTransaction>> GetByOrderIdAsync(int orderId);
    }

}
