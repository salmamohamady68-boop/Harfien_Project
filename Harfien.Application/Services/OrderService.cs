using AutoMapper;
using Harfien.Application.DTO.Error;
using Harfien.Application.DTO.Order;
using Harfien.Application.Interfaces;
using Harfien.Domain.Entities;
using Harfien.Domain.Enums;
using Harfien.Domain.Shared.Repositories;
namespace Harfien.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICraftsmanRepository _craftsmanRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IAvailabilityRepository _availabilityRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;

        public OrderService(
            IOrderRepository orderRepository,
            ICraftsmanRepository craftsmanRepository,
            IClientRepository clientRepository,
            IAvailabilityRepository availabilityRepository,
            IServiceRepository serviceRepository,
            IMapper mapper)
        {
            _orderRepository = orderRepository;
            _craftsmanRepository = craftsmanRepository;
            _clientRepository = clientRepository;
            _availabilityRepository = availabilityRepository;
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }

        // ================= CREATE =================
        public async Task<OrderResponseDto?> CreateAsync(
            CreateOrderDto dto,
            int clientId,
            List<FieldErrorDto> serviceErrors)
        {
            var client = await _clientRepository.GetByIdAsync(clientId);
            if (client == null)
                serviceErrors.Add(new FieldErrorDto { Field = "Client", Message = "Client not found" });

            var craftsman = await _craftsmanRepository.GetByIdAsync(dto.CraftsmanId);
            if (craftsman == null)
                serviceErrors.Add(new FieldErrorDto { Field = nameof(dto.CraftsmanId), Message = "Craftsman not found" });

            var service = await _serviceRepository.GetByIdAsync(dto.ServiceId);
            if (service == null)
                serviceErrors.Add(new FieldErrorDto { Field = nameof(dto.ServiceId), Message = "Service not found" });

            if (dto.ScheduledAt <= DateTime.Now)
                serviceErrors.Add(new FieldErrorDto { Field = nameof(dto.ScheduledAt), Message = "Cannot book in the past" });

            if (serviceErrors.Any())
                return null;

            var isAvailable = await _availabilityRepository
                .IsAvailableAsync(dto.CraftsmanId, dto.ScheduledAt);

            if (!isAvailable)
            {
                serviceErrors.Add(new FieldErrorDto
                {
                    Field = nameof(dto.ScheduledAt),
                    Message = "Craftsman not available at this time"
                });
                return null;
            }

            var isBooked = await _orderRepository
                .ExistsAsync(dto.CraftsmanId, dto.ScheduledAt);

            if (isBooked)
            {
                serviceErrors.Add(new FieldErrorDto
                {
                    Field = nameof(dto.ScheduledAt),
                    Message = "This slot is already booked"
                });
                return null;
            }

            var order = new Order
            {
                ClientId = clientId,
                CraftsmanId = dto.CraftsmanId,
                ServiceId = dto.ServiceId,
                Description = dto.Description,
                ScheduledAt = dto.ScheduledAt.ToUniversalTime(),
                Status = OrderStatus.Pending,
                Amount = service!.Price
            };

            await _orderRepository.AddAsync(order);
            await _orderRepository.SaveAsync();

            var createdOrder =
                await _orderRepository.GetByIdWithDetailsAsync(order.Id);

            return _mapper.Map<OrderResponseDto>(createdOrder);
        }

        // ================= GET BY ID =================
        public async Task<OrderResponseDto?> GetByIdAsync(
            int id,
            List<FieldErrorDto> serviceErrors)
        {
            var order = await _orderRepository.GetByIdWithDetailsAsync(id);

            if (order == null)
            {
                serviceErrors.Add(new FieldErrorDto
                {
                    Field = "Id",
                    Message = "Order not found"
                });
                return null;
            }

            return _mapper.Map<OrderResponseDto>(order);
        }

        // ================= CLIENT ORDERS =================
        public async Task<IEnumerable<OrderInfoDto>?> GetClientOrdersAsync(
            int clientId,
            List<FieldErrorDto> serviceErrors)
        {
            var orders = await _orderRepository.GetByClientIdAsync(clientId);

            if (!orders.Any())
            {
                serviceErrors.Add(new FieldErrorDto
                {
                    Field = "ClientId",
                    Message = "No orders found for this client"
                });
                return null;
            }

            return _mapper.Map<IEnumerable<OrderInfoDto>>(orders);
        }

        // ================= CRAFTSMAN ORDERS =================
        public async Task<IEnumerable<OrderInfoDto>?> GetCraftsmanOrdersAsync(
            int craftsmanId,
            List<FieldErrorDto> serviceErrors)
        {
            var orders = await _orderRepository.GetByCraftsmanIdAsync(craftsmanId);

            if (!orders.Any())
            {
                serviceErrors.Add(new FieldErrorDto
                {
                    Field = "CraftsmanId",
                    Message = "No orders found for this craftsman"
                });
                return null;
            }

            return _mapper.Map<IEnumerable<OrderInfoDto>>(orders);
        }

        // ================= STATUS UPDATE =================
        private async Task UpdateStatusAsync(
            int orderId,
            int userId,
            bool isClient,
            OrderStatus newStatus,
            List<FieldErrorDto> serviceErrors)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);

            if (order == null)
            {
                serviceErrors.Add(new FieldErrorDto
                {
                    Field = "OrderId",
                    Message = "Order not found"
                });
                return;
            }

            if (isClient && order.ClientId != userId ||
               !isClient && order.CraftsmanId != userId)
            {
                serviceErrors.Add(new FieldErrorDto
                {
                    Field = "Authorization",
                    Message = "You are not allowed to modify this order"
                });
                return;
            }

            if (!IsValidTransition(order.Status, newStatus))
            {
                serviceErrors.Add(new FieldErrorDto
                {
                    Field = "Status",
                    Message = "Invalid status transition"
                });
                return;
            }

            order.Status = newStatus;

            _orderRepository.Update(order);
            await _orderRepository.SaveAsync();
        }

        private bool IsValidTransition(OrderStatus current, OrderStatus next)
        {
            return (current, next) switch
            {
                (OrderStatus.Pending, OrderStatus.Accepted) => true,
                (OrderStatus.Pending, OrderStatus.Rejected) => true,
                (OrderStatus.Pending, OrderStatus.Cancelled) => true,
                (OrderStatus.Accepted, OrderStatus.Running) => true,
                (OrderStatus.Accepted, OrderStatus.Cancelled) => true,
                (OrderStatus.Running, OrderStatus.Completed) => true,
                _ => false
            };
        }

        public Task AcceptAsync(int orderId, int craftsmanId, List<FieldErrorDto> serviceErrors)
            => UpdateStatusAsync(orderId, craftsmanId, false, OrderStatus.Accepted, serviceErrors);

        public Task RejectAsync(int orderId, int craftsmanId, List<FieldErrorDto> serviceErrors)
            => UpdateStatusAsync(orderId, craftsmanId, false, OrderStatus.Rejected, serviceErrors);

        public Task StartAsync(int orderId, int craftsmanId, List<FieldErrorDto> serviceErrors)
            => UpdateStatusAsync(orderId, craftsmanId, false, OrderStatus.Running, serviceErrors);

        public Task CompleteAsync(int orderId, int craftsmanId, List<FieldErrorDto> serviceErrors)
            => UpdateStatusAsync(orderId, craftsmanId, false, OrderStatus.Completed, serviceErrors);

        public Task CancelAsync(int orderId, int clientId, List<FieldErrorDto> serviceErrors)
            => UpdateStatusAsync(orderId, clientId, true, OrderStatus.Cancelled, serviceErrors);
    }
}