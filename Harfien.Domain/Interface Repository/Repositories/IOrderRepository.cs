using Harfien.Domain.Entities;
using Harfien.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harfien.Domain.Shared.Repositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task AddAsync(Order order);
        Task<Order?> GetByIdAsync(int id);
        Task<List<Order>> GetAllAsync();
        Task UpdateAsync(Order order);
        Task DeleteAsync(Order order);
    }

}
