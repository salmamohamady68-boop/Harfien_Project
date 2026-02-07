using Harfien.DataAccess;
using Harfien.Domain.Entities;
using Harfien.Domain.Shared.Repositories;

namespace Harfien.Infrastructure.Repositories
{
    public class ComplaintRepository : GenericRepository<Complaint>, IComplaintRepository
    {
        public ComplaintRepository(HarfienDbContext context) : base(context) { }
    }
}