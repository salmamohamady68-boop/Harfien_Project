using Harfien.Application.DTO.Error;
using Harfien.Application.DTO.ServiceCategory;
using Harfien.Application.Interfaces;
using Harfien.Domain.Entities;
using Harfien.Domain.Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Harfien.Application.Services
{
    public class ServiceCategoryService : IServiceCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServiceCategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // ================= Get All Categories =================
        public async Task<IEnumerable<ServiceCategoryDto>> GetAllAsync()
        {
            var categories = await _unitOfWork.ServiceCategories.GetAllAsync();

            return categories.Select(c => new ServiceCategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                Type = c.Type,
                Description = c.Description
            });
        }

        // ================= Get By Id =================
        public async Task<ServiceCategoryDto?> GetByIdAsync(int id,List<FieldErrorDto> serviceErrors)
        {
            var entity = await _unitOfWork.ServiceCategories.GetByIdAsync(id);

            if (entity == null)
            {
                serviceErrors.Add(new FieldErrorDto
                {
                    Field = "Id",
                    Message = "Service Category Not Found"
                });
                return null;
            }

            return new ServiceCategoryDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Type = entity.Type,
                Description = entity.Description
            };
        }
        // ================= Add Category =================
        public async Task<ServiceCategoryDto> AddAsync(AddServiceCategoryDto dto)
        {
            var entity = new ServiceCategory
            {
                Name = dto.Name,
                Type = dto.Type,
                Description = dto.Description,
                CreatedAt = DateTime.UtcNow
            };

            await _unitOfWork.ServiceCategories.AddAsync(entity);
            await _unitOfWork.SaveAsync();

            // ارجع DTO بعد الإضافة مع الـ ID الجديد
            return new ServiceCategoryDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Type = entity.Type,
                Description = entity.Description
            };
        }

        // ================= Update Category =================
        public async Task<ServiceCategoryDto?> UpdateAsync(
        ServiceCategoryDto dto,
        List<FieldErrorDto> serviceErrors)
        {
            var entity = await _unitOfWork.ServiceCategories.GetByIdAsync(dto.Id);

            if (entity == null)
            {
                serviceErrors.Add(new FieldErrorDto
                {
                    Field = "Id",
                    Message = "Service Category Not Found"
                });
                return null;
            }

            entity.Name = dto.Name;
            entity.Type = dto.Type;
            entity.Description = dto.Description;

            _unitOfWork.ServiceCategories.Update(entity);
            await _unitOfWork.SaveAsync();

            return new ServiceCategoryDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Type = entity.Type,
                Description = entity.Description
            };
        }
        // ================= Delete Category =================
        // ================= Delete Category =================
        public async Task<ServiceCategoryDto?> DeleteAsync( int id, List<FieldErrorDto> serviceErrors)
        {
            var entity = await _unitOfWork.ServiceCategories.GetByIdAsync(id);

            if (entity == null)
            {
                serviceErrors.Add(new FieldErrorDto
                {
                    Field = "Id",
                    Message = "Service Category Not Found"
                });
                return null;
            }
            if (await _unitOfWork.ServiceCategories.HasServicesAsync(id))
            {
                serviceErrors.Add(new FieldErrorDto { Field = "Id", Message = "Cannot delete category with services" });
                return null;
            }

            _unitOfWork.ServiceCategories.Delete(entity);
            await _unitOfWork.SaveAsync();

            return new ServiceCategoryDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Type = entity.Type,
                Description = entity.Description
            };
        }
    }
}