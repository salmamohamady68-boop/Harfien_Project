using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Harfien.Application.DTO;

namespace Harfien.Application.Interfaces
{
    public interface IServiceService
    {
        Task<ServiceReadDto> CreateServiceAsync(ServiceCreateDto dto);
        Task<ServiceReadDto> UpdateServiceAsync(int id,ServiceUpdateDto dto);
        Task  DeleteServiceAsync(int id);
    }
}
