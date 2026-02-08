using AutoMapper;
using Harfien.Application.DTO;
using Harfien.Application.Interfaces;
using Harfien.Domain.Entities;
using Harfien.Domain.Enums;
using Harfien.Domain.Shared.Repositories;

namespace Harfien.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repo;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(CreateOrderDto dto, int clientId)
        {
            var order = _mapper.Map<Order>(dto);
            order.ClientId = clientId;
            order.Status = OrderStatus.New;

            await _repo.AddAsync(order);
            await _repo.SaveAsync();
            return order.Id;
        }

        public async Task<OrderResponseDto> GetByIdAsync(int id)
        {
            var order = await _repo.GetByIdWithDetailsAsync(id)
                ?? throw new KeyNotFoundException($"Order with ID {id} not found");

            return _mapper.Map<OrderResponseDto>(order);
        }

        public async Task<IEnumerable<OrderResponseDto>> GetClientOrdersAsync(int clientId)
        {
            var orders = await _repo.GetByClientIdAsync(clientId);
            return _mapper.Map<IEnumerable<OrderResponseDto>>(orders);
        }

        public async Task<IEnumerable<OrderResponseDto>> GetCraftsmanOrdersAsync(int craftsmanId)
        {
            var orders = await _repo.GetByCraftsmanIdAsync(craftsmanId);
            return _mapper.Map<IEnumerable<OrderResponseDto>>(orders);
        }

        public async Task<IEnumerable<OrderResponseDto>> GetAllAsync()
        {
            var orders = await _repo.GetAllWithDetailsAsync();
            return _mapper.Map<IEnumerable<OrderResponseDto>>(orders);
        }

        public async Task<IEnumerable<OrderResponseDto>> GetByStatusAsync(OrderStatus status)
        {
            var orders = await _repo.GetByStatusAsync(status);
            return _mapper.Map<IEnumerable<OrderResponseDto>>(orders);
        }

        public async Task AcceptAsync(int orderId, int craftsmanId)
        {
            var order = await _repo.GetByIdAsync(orderId)
                ?? throw new KeyNotFoundException($"Order with ID {orderId} not found");

            if (order.CraftsmanId != craftsmanId)
                throw new UnauthorizedAccessException("You are not authorized to accept this order");

            if (order.Status != OrderStatus.New)
                throw new InvalidOperationException($"Cannot accept order with status: {order.Status}");

            order.Status = OrderStatus.Running;
            _repo.Update(order);
            await _repo.SaveAsync();
        }

        public async Task StartAsync(int orderId, int craftsmanId)
        {
            var order = await _repo.GetByIdAsync(orderId)
                ?? throw new KeyNotFoundException($"Order with ID {orderId} not found");

            if (order.CraftsmanId != craftsmanId)
                throw new UnauthorizedAccessException("You are not authorized to start this order");

            if (order.Status != OrderStatus.Running)
                throw new InvalidOperationException("Order must be accepted first");

            // Add any additional logic for starting the order here
            await _repo.SaveAsync();
        }

        public async Task CompleteAsync(int orderId, int craftsmanId)
        {
            var order = await _repo.GetByIdAsync(orderId)
                ?? throw new KeyNotFoundException($"Order with ID {orderId} not found");

            if (order.CraftsmanId != craftsmanId)
                throw new UnauthorizedAccessException("You are not authorized to complete this order");

            if (order.Status != OrderStatus.Running)
                throw new InvalidOperationException($"Cannot complete order with status: {order.Status}");

            order.Status = OrderStatus.Complete;
            _repo.Update(order);
            await _repo.SaveAsync();
        }

        public async Task CancelAsync(int orderId, int clientId)
        {
            var order = await _repo.GetByIdAsync(orderId)
                ?? throw new KeyNotFoundException($"Order with ID {orderId} not found");

            if (order.ClientId != clientId)
                throw new UnauthorizedAccessException("You are not authorized to cancel this order");

            if (order.Status != OrderStatus.New)
                throw new InvalidOperationException("Cannot cancel order after it has been accepted");

            order.Status = OrderStatus.Cancelled; // ✅ Better to mark as cancelled instead of delete
            _repo.Update(order);
            await _repo.SaveAsync();
        }
    }
}