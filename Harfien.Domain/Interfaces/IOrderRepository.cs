using Harfien.Domain.Entites;
using Harfien.Domain.Enums;
using Harfien.Domain.Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harfien.Domain.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<Order?> GetByIdWithDetailsAsync(int id);

        Task<IEnumerable<Order>> GetByClientIdAsync(int clientId);
        Task<IEnumerable<Order>> GetByCraftsmanIdAsync(int craftsmanId);

        Task<IEnumerable<Order>> GetByStatusAsync(OrderStatus status);
        Task<IEnumerable<Order>> GetAllWithDetailsAsync();

        Task<bool> IsOrderBelongsToClientAsync(int orderId, int clientId);
    }

}
