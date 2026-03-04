using Harfien.Application.DTO.Error;
using Harfien.Application.DTO.ServiceCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harfien.Application.Interfaces
{
    public interface IServiceCategoryService
    {
        Task<IEnumerable<ServiceCategoryDto>> GetAllAsync();
        Task<ServiceCategoryDto> GetByIdAsync(int id, List<FieldErrorDto> serviceErrors);
        Task<ServiceCategoryDto> AddAsync(AddServiceCategoryDto dto);
        Task<ServiceCategoryDto> UpdateAsync(ServiceCategoryDto entity, List<FieldErrorDto> serviceErrors);
        Task<ServiceCategoryDto> DeleteAsync(int id, List<FieldErrorDto> serviceErrors);
    }

}
