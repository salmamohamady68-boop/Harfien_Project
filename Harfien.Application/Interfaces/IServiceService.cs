using Harfien.Application.DTO.Error;
using Harfien.Application.DTO.Service;
using Harfien.Domain.Shared;

namespace Harfien.Application.Interfaces
{
    public interface IServiceService
    {
        Task<ServiceReadDto> CreateServiceAsync(ServiceCreateDto dto, List<FieldErrorDto> serviceErrors);
        Task<ServiceReadDto> UpdateServiceAsync(int id,ServiceUpdateDto dto, List<FieldErrorDto> serviceErrors);
        Task<bool> DeleteServiceAsync(int id);

        Task<ServiceReadDto> GetServiceByIdAsync(int id);
        Task<IEnumerable<ServiceReadDto>> GetAllServicesAsync();
        Task<PagedResult<ServiceReadDto>> GetServicesByCategoryAsync(int categoryId, int pageNumber, int pageSize, List<FieldErrorDto> serviceErrors);

        Task<PagedResult<ServiceReadDto>> GetFilteredAsync(ServiceQueryDto query);
        Task<PagedResult<ServiceReadDto>> GetServicesByCraftsmanIdAsync(int craftsmanId,
    int pageNumber,
    int pageSize, List<FieldErrorDto> serviceErrors);

    }
}
