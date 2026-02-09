using Harfien.Application.DTO;

namespace Harfien.Application.Interfaces
{
    public interface IServiceService
    {
        Task<ServiceReadDto> CreateServiceAsync(ServiceCreateDto dto);
        Task<ServiceReadDto> UpdateServiceAsync(int id,ServiceUpdateDto dto);
        Task  DeleteServiceAsync(int id);
    }
}
