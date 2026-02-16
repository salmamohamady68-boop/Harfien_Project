using Harfien.DataAccess;
using Harfien.Domain.Entities;
using Harfien.Domain.Shared.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harfien.Infrastructure.Repositories
{
    public class AvailabilityRepository
       : GenericRepository<CraftsmanAvailability>, IAvailabilityRepository
    {
        public AvailabilityRepository(HarfienDbContext context) : base(context) { }

        public async Task<bool> IsAvailableAsync(int craftsmanId, DateTime dateTime)
        {
            return await _dbSet.AnyAsync(a =>
                a.CraftsmanId == craftsmanId &&
                a.Day == dateTime.DayOfWeek &&
                a.From <= dateTime.TimeOfDay &&
                a.To >= dateTime.TimeOfDay &&
                a.IsAvailable
            );
        }

        public async Task<IEnumerable<int>> GetAvailableCraftsmenIdsAsync(DateTime dateTime)
        {
            return await _dbSet
                .Where(a =>
                    a.Day == dateTime.DayOfWeek &&
                    a.From <= dateTime.TimeOfDay &&
                    a.To >= dateTime.TimeOfDay &&
                    a.IsAvailable
                )
                .Select(a => a.CraftsmanId)
                .Distinct()
                .ToListAsync();
        }
        public async Task<IEnumerable<CraftsmanAvailability>> GetAllByCraftsmanIdAsync(int craftsmanId)
        {
            return await _dbSet.Where(a => a.CraftsmanId == craftsmanId).ToListAsync();
        }

    }

}
