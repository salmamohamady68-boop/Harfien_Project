using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Harfien.DataAccess;
using Harfien.Domain.Shared.Repositories;

namespace Harfien.Infrastructure.Repositories
{
    public class UnitOfWork(HarfienDbContext _context) : IUnitOfWork

    {
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
