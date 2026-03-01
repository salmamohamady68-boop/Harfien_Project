using System.Xml.Schema;
using Harfien.Domain.Entities;

namespace Harfien.Domain.Shared.Repositories
{
    public interface IServiceRepository : IGenericRepository<Service>
    {
        Task<List<Service>> GetAllServicesWithCraftData();
        Task<Service?> GetServiceByIdWithCraftData(int id);
        Task<List<Service>> GetServicesByCategory( int id);
        Task<PagedResult<Service>> GetServicesByCategoryAsync( int categoryId, int pageNumber,  int pageSize);
        Task<PagedResult<Service>> GetFilteredAsync(ServiceQueryDto query);
        Task<PagedResult<Service>> GetServicesByCraftsmanIdAsync(int craftsmanId, int pageNumber, int pageSize);
        Task<bool> CraftsmanExistsAsync(int craftsmanId);
        Task<bool> CategoryExistsAsync(int categoryId);
        Task<bool> ServiceExistsAsync(string name, int craftsmanId);


    }
}