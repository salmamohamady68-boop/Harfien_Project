using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Harfien.Domain.Entities;

namespace Harfien.Domain.Shared.Repositories
{
    public interface ICraftsmanRepository : IGenericRepository<Craftsman>
    {
        Task<IEnumerable<Craftsman>> GetAvailableByServiceAsync(int serviceId);
        Task<Craftsman?> GetWithServicesAsync(int craftsmanId);
        Task<Craftsman?> GetByUserIdAsync(string userId);
        Task UpdateAsync(Craftsman craftsman);

        Task<Craftsman?> GetByUserIdWithIncludeAsync(string userId);
        Task<Craftsman?> GetProfileAsync(int id);

        Task<List<Review>?> GetReviewAsync(int craftmanid);
    }

}
