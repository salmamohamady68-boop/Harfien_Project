using Harfien.Domain.Entities;

namespace Harfien.Domain.Shared.Repositories
{
    public interface IAreaRepository
    {
        Task<IEnumerable<Area>> GetAllAsync();
        Task<Area?> GetByIdAsync(int id);
    }
}