using Harfien.Application.DTO;
using Harfien.Domain.Entities;
using Harfien.Domain.Enums;

namespace Harfien.Application.Interfaces
{
    public interface IOrderService
    {
        Task<int> CreateOrderAsync(CreateOrderDto dto);
        Task<List<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(int id, UpdateOrderDto dto);
        Task<bool> DeleteAsync(int id);
    }
}