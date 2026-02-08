using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Harfien.Application.DTO;
using Harfien.Application.Interfaces;
using Harfien.Domain.Entities;
using Harfien.Domain.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ServiceReadDto> CreateServiceAsync(ServiceCreateDto dto)
        {
            var service = _mapper.Map<Service>(dto);

             await _serviceRepository.AddAsync(service);

             await _serviceRepository.SaveAsync();


            return _mapper.Map<ServiceReadDto>(service);

            


        }

        public async Task  DeleteServiceAsync(int id)
        {
            var service = await _serviceRepository.GetByIdAsync(id);


            _serviceRepository.Delete(service);
            await _serviceRepository.SaveAsync();
        }

        public async Task<ServiceReadDto> UpdateServiceAsync(int id, ServiceUpdateDto dto)
        {
            var service = await _serviceRepository.GetByIdAsync(id);
            _mapper.Map(dto, service);
            _serviceRepository.Update(service);
            await _serviceRepository.SaveAsync();
            return _mapper.Map<ServiceReadDto>(service);




        }
    }
}
