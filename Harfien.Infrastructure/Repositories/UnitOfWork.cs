using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Harfien.DataAccess;
using Harfien.Domain.Shared.Repositories;

namespace Harfien.Infrastructure.Repositories
{
    public class UnitOfWork  : IUnitOfWork

    {
        private readonly HarfienDbContext _context;


        public UnitOfWork( HarfienDbContext context,
            IClientRepository clients,
            ICraftsmanRepository craftsmen,
            IApplicationUserRepository users)
        {
            _context = context;
            Clients = clients;
            Craftsmen = craftsmen;
            Users = users;
        }
        public IClientRepository Clients { get; }
        public ICraftsmanRepository Craftsmen { get; }
        public IApplicationUserRepository Users { get; }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
