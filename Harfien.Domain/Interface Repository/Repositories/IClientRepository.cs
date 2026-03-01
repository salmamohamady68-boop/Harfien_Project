using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Harfien.Domain.Entities;

namespace Harfien.Domain.Shared.Repositories
{
    public interface IClientRepository : IGenericRepository<Client>
    {
        Task<List<Client>> GetAllWithIncludesAsync();
        Task<Client?> GetByIdWithIncludesAsync(int id);
        Task DeleteAsync(Client client);
        Task SaveAsync();
        Task<Client?> GetClientWithOrdersAsync(int clientId);
        Task<Client?> GetByUserIdAsync(string userId);
        Task<List<Client>> SearchAsync(string keyword);
    }
}
