using Harfien.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harfien.Application.Interfaces
{
    public interface IAvailabilityService
    {
        Task AddAvailabilityAsync(CreateAvailabilityDto dto, string userId);
        Task<IEnumerable<AvailabilityreadDto>> GetMyAvailabilityAsync(string userId);
        Task UpdateMyAvailabilityAsync(List<CreateAvailabilityDto> dtos, string userId);
     

    }
}
