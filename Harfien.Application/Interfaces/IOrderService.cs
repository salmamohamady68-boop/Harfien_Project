using Harfien.Application.DTO.Error;
using Harfien.Application.DTO.Order;
using Harfien.Domain.Enums;

namespace Harfien.Application.Interfaces
{
    
        public interface IOrderService
        {
            Task<OrderResponseDto?> CreateAsync( CreateOrderDto dto, int clientId,  List<FieldErrorDto> serviceErrors);

            Task<OrderResponseDto?> GetByIdAsync(int id, List<FieldErrorDto> serviceErrors);

            Task<IEnumerable<OrderResponseDto>?> GetClientOrdersAsync(int clientId,List<FieldErrorDto> serviceErrors);

            Task<IEnumerable<OrderResponseDto>?> GetCraftsmanOrdersAsync( int craftsmanId,List<FieldErrorDto> serviceErrors);

            Task AcceptAsync(int orderId, int craftsmanId, List<FieldErrorDto> serviceErrors);
            Task RejectAsync(int orderId, int craftsmanId, List<FieldErrorDto> serviceErrors);
            Task StartAsync(int orderId, int craftsmanId, List<FieldErrorDto> serviceErrors);
            Task CompleteAsync(int orderId, int craftsmanId, List<FieldErrorDto> serviceErrors);
            Task CancelAsync(int orderId, int clientId, List<FieldErrorDto> serviceErrors);
        }
    
}