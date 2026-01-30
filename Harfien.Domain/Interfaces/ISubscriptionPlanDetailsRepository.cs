using Harfien.Domain.Entities;
using Harfien.Domain.Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harfien.Domain.Interfaces
{
    public interface ISubscriptionPlanDetailsRepository
    : IGenericRepository<SubscriptionPlanDetails>
    {
        Task<IEnumerable<SubscriptionPlanDetails>> GetByPlanIdAsync(int planId);
        Task DeleteByPlanIdAsync(int planId);
    }

}
