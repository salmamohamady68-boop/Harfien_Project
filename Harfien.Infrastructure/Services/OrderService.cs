using Harfien.Application.DTO;
using Harfien.Application.Interfaces;
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

namespace Harfien.Infrastructure.Services
{
    public class OrderService : IOrderService
    {
       
            private readonly HarfienDbContext _context;
            private readonly IOrderRepository _orderRepository;

            public OrderService(HarfienDbContext context, IOrderRepository orderRepository)
            {
                _context = context;
                _orderRepository = orderRepository;
            }

            public async Task<int> CreateOrderAsync(CreateOrderDto dto)
            {
                // ✅ Check Client exists
                var client = await _context.Clients
                    .FirstOrDefaultAsync(c => c.Id == dto.ClientId);

                if (client == null)
                    throw new Exception("Client not found");

                // ✅ Check Craftsman exists
                var craftsman = await _context.Craftsmen
                    .FirstOrDefaultAsync(c => c.Id == dto.CraftsmanId);

                if (craftsman == null)
                    throw new Exception("Craftsman not found");

                // ✅ Check Service exists
                var service = await _context.Services
                    .FirstOrDefaultAsync(s => s.Id == dto.ServiceId);

                if (service == null)
                    throw new Exception("Service not found");

                var order = new Order
                {
                    ClientId = dto.ClientId,
                    CraftsmanId = dto.CraftsmanId,
                    ServiceId = dto.ServiceId,
                    Description = dto.Description,
                    ScheduledAt = dto.ScheduledAt,
                    Amount = dto.Amount,
                    Status = OrderStatus.Pending
                };

                await _orderRepository.AddAsync(order);

                return order.Id;
            }

            public async Task<List<Order>> GetAllAsync()
                => await _orderRepository.GetAllAsync();

            public async Task<Order?> GetByIdAsync(int id)
                => await _orderRepository.GetByIdAsync(id);

            public async Task<bool> UpdateAsync(int id, UpdateOrderDto dto)
            {
                var order = await _orderRepository.GetByIdAsync(id);
                if (order == null)
                    return false;

                order.Description = dto.Description;
                order.ScheduledAt = dto.ScheduledAt;
                order.Status = dto.Status;
                order.Amount = dto.Amount;

                await _orderRepository.UpdateAsync(order);
                return true;
            }

            public async Task<bool> DeleteAsync(int id)
            {
                var order = await _orderRepository.GetByIdAsync(id);
                if (order == null)
                    return false;

                await _orderRepository.DeleteAsync(order);
                return true;
            }
    }
}
