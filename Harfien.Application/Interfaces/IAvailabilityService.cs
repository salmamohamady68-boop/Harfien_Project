using Harfien.Application.DTO.CraftsmanAvailiability;
using Harfien.Application.DTO.Error;
using Harfien.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harfien.Application.Interfaces
{
    public interface IAvailabilityService
    {
        Task<AvailabilityreadDto> AddAvailabilityAsync(
                CreateAvailabilityDto dto,
                string userId,
                List<FieldErrorDto> serviceErrors);

        //Task<IEnumerable<AvailabilityreadDto>> GetMyAvailabilityAsync(string userId);
        Task<IEnumerable<AvailabilityreadDto>> GetCraftsmanAvailabilityAsync(int craftsmanId);
        Task<AvailabilityreadDto> UpdateMyAvailabilityAsync(List<CreateAvailabilityDto> dtos, string userId, List<FieldErrorDto> serviceErrors);

     

    }
}
