using Harfien.Domain.Entites;
using Harfien.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harfien.Domain.Shared.Repositories
{
    // Renamed the interface to avoid the CS0101 conflict
    public interface IAvailabilityRepository : IGenericRepository<CraftsmanAvailability>
    {
        Task<bool> IsAvailableAsync(int craftsmanId, DateTime dateTime);
        Task<IEnumerable<int>> GetAvailableCraftsmenIdsAsync(DateTime dateTime);
    }

}
