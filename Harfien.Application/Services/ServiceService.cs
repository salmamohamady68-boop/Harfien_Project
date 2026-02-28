using AutoMapper;
using Harfien.Application.DTO.Error;
using Harfien.Application.DTO.Service;
using Harfien.Application.Interfaces;
using Harfien.Domain.Entities;
using Harfien.Domain.Shared;
using Harfien.Domain.Shared.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Harfien.Application.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IMapper _mapper;
        private readonly IServiceRepository _serviceRepository;

        public  ServiceService(IMapper mapper,IServiceRepository serviceRepository) {
            _mapper = mapper;
           _serviceRepository = serviceRepository;
        }
        #region crud op
        public async Task<ServiceReadDto> CreateServiceAsync(ServiceCreateDto dto, List<FieldErrorDto> serviceErrors)
        {
            if (dto.CraftsmanId.HasValue)
            {
                if (!await _serviceRepository.CraftsmanExistsAsync(dto.CraftsmanId.Value))
                {
                    serviceErrors.Add(new FieldErrorDto
                    {
                        Field = nameof(dto.CraftsmanId),
                        Message = "Craftsman not found."
                    });
                }

                if (await _serviceRepository.ServiceExistsAsync(dto.Name, dto.CraftsmanId.Value))
                {
                    serviceErrors.Add(new FieldErrorDto
                    {
                        Field = nameof(dto.Name),
                        Message = "Service with the same name already exists for this craftsman."
                    });
                }
            }

      
            if (dto.ServiceCategoryId.HasValue)
            {
                if (!await _serviceRepository.CategoryExistsAsync(dto.ServiceCategoryId.Value))
                {
                    serviceErrors.Add(new FieldErrorDto
                    {
                        Field = nameof(dto.ServiceCategoryId),
                        Message = "Service category not found."
                    });
                }
            }



            if (serviceErrors.Any())
                return null;

          
            try
            {
                var service = _mapper.Map<Service>(dto);

                await _serviceRepository.AddAsync(service);
                await _serviceRepository.SaveAsync();

                var serviceWithRelations = await _serviceRepository.GetServiceByIdWithCraftData(service.Id);

                return _mapper.Map<ServiceReadDto>(serviceWithRelations);
            }
            catch (Exception ex)
            {
                return null;

            }
        }
        public async Task<bool> DeleteServiceAsync(int id)
        {
            var service = await _serviceRepository.GetByIdAsync(id);

            if (service == null)
                return false;  

            _serviceRepository.Delete(service);
            await _serviceRepository.SaveAsync();
            return true;  
        }


       
        public async Task<ServiceReadDto> UpdateServiceAsync(int id, ServiceUpdateDto dto, List<FieldErrorDto> serviceErrors)
        {
            if (dto.CraftsmanId.HasValue)
            {
                if (!await _serviceRepository.CraftsmanExistsAsync(dto.CraftsmanId.Value))
                {
                    serviceErrors.Add(new FieldErrorDto
                    {
                        Field = nameof(dto.CraftsmanId),
                        Message = "Craftsman not found."
                    });
                }

               
            }


            if (dto.ServiceCategoryId.HasValue)
            {
                if (!await _serviceRepository.CategoryExistsAsync(dto.ServiceCategoryId.Value))
                {
                    serviceErrors.Add(new FieldErrorDto
                    {
                        Field = nameof(dto.ServiceCategoryId),
                        Message = "Service category not found."
                    });
                }
            }



            if (serviceErrors.Any())
                return null;

            var service = await _serviceRepository.GetByIdAsync(id);
            _mapper.Map(dto, service);
            _serviceRepository.Update(service);
            await _serviceRepository.SaveAsync();
            var serviceWithRelations = await _serviceRepository.GetServiceByIdWithCraftData(service.Id);

            return _mapper.Map<ServiceReadDto>(serviceWithRelations);




        }
        #endregion

        public async Task<IEnumerable<ServiceReadDto>> GetAllServicesAsync()
        {
           var services= await _serviceRepository.GetAllServicesWithCraftData();
            return _mapper.Map<List<ServiceReadDto>>(services);
        }

        public async Task<ServiceReadDto> GetServiceByIdAsync(int id)
        {
            var service = await _serviceRepository.GetServiceByIdWithCraftData(id);
            return _mapper.Map<ServiceReadDto>(service);
        }

        public async Task<PagedResult<ServiceReadDto>> GetServicesByCategoryAsync(int categoryId, int pageNumber, int pageSize, List<FieldErrorDto> serviceErrors)
        {
            if (!await _serviceRepository.CategoryExistsAsync(categoryId))
            {
                serviceErrors.Add(new FieldErrorDto
                {
                    Field = nameof(categoryId),
                    Message = "Service category not found."
                });
            }
            var services = await _serviceRepository.GetServicesByCategoryAsync(categoryId,pageNumber,pageSize);
           if( await _serviceRepository.CategoryExistsAsync(categoryId))
           { if (!services.Items.Any())
                {
                    serviceErrors.Add(new FieldErrorDto
                    {
                        Field = nameof(categoryId),
                        Message = "No services found for the specified category"
                    });
                }
            }
            if (serviceErrors.Any())
                return null;
           
            return new PagedResult<ServiceReadDto>
            {
                Items = _mapper.Map<IEnumerable<ServiceReadDto>>(services.Items),
                TotalCount = services.TotalCount,
                PageNumber = services.PageNumber,
                PageSize = services.PageSize
            };

        }

        public async Task<PagedResult<ServiceReadDto>> GetFilteredAsync(ServiceQueryDto query)
        {
            var result = await _serviceRepository.GetFilteredAsync(query);

            return new PagedResult<ServiceReadDto>
            {
                Items = _mapper.Map<IEnumerable<ServiceReadDto>>(result.Items),
                TotalCount = result.TotalCount,
                PageNumber = result.PageNumber,
                PageSize = result.PageSize
            };
        }

        public async Task<PagedResult<ServiceReadDto>> GetServicesByCraftsmanIdAsync(int craftsmanId, int pageNumber, int pageSize, List<FieldErrorDto> serviceErrors)
        {
            if (!await _serviceRepository.CraftsmanExistsAsync(craftsmanId))
            {
                serviceErrors.Add(new FieldErrorDto
                {
                    Field = nameof(craftsmanId),
                    Message = "Craftsman not found."
                });
            }

            if (serviceErrors.Any())
                return null;
            var result = await _serviceRepository.GetServicesByCraftsmanIdAsync( craftsmanId,   pageNumber,   pageSize);
            if (await _serviceRepository.CraftsmanExistsAsync(craftsmanId))
            {
                if (!result.Items.Any())
                {
                    serviceErrors.Add(new FieldErrorDto
                    {
                        Field = nameof(craftsmanId),
                        Message = "No services found for the specified craftmane"
                    });
                }
            }
                return new PagedResult<ServiceReadDto>
            {
                Items = _mapper.Map<IEnumerable<ServiceReadDto>>(result.Items),
                TotalCount = result.TotalCount,
                PageNumber = result.PageNumber,
                PageSize = result.PageSize
            };
        }
    }
}
