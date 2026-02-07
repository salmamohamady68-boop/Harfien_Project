using System.Xml.Schema;
using Harfien.Domain.Entities;

namespace Harfien.Domain.Shared.Repositories
{
    public interface IServiceRepository : IGenericRepository<Service>
    {
        Task<List<Service>> GetAllServicesWithCraftData();
        Task<Service?> GetServiceByIdWithCraftData(int id);
    }
}