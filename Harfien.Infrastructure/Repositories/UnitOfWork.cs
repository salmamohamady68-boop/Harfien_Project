using Harfien.DataAccess;
using Harfien.Domain.Shared.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harfien.Infrastructure.Repositories
{
    public class UnitOfWork  : IUnitOfWork

    {
        private readonly HarfienDbContext _context;
        private IServiceCategoryRepository _serviceCategories;
        private IComplaintRepository _complaintRepository;


        public UnitOfWork( HarfienDbContext context,
            IClientRepository clients,
            ICraftsmanRepository craftsmen)
        {
            _context = context;
            Clients = clients;
            Craftsmen = craftsmen;
        }
        public IClientRepository Clients { get; }
        public ICraftsmanRepository Craftsmen { get; }
      

        public IServiceCategoryRepository ServiceCategories
        {
            get
            {
                if (_serviceCategories == null)
                {
                    _serviceCategories = new ServiceCategoryRepository(_context);
                }

                return _serviceCategories;
            }
        }

        public IComplaintRepository ComplaintRepository
        {
            get
            {
                if (_complaintRepository == null)
                {
                    _complaintRepository = new ComplaintRepository(_context);
                }

                return _complaintRepository;
            }
        }



        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }
    }
}
