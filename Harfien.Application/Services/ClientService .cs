using E_Learning.Service.Contract;
using Harfien.Application.DTO;
using Harfien.Application.Exceptions;
using Harfien.Application.Interfaces;
using Harfien.Domain.Entities;
using Harfien.Domain.Shared.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harfien.Application.Services
{
    public  class ClientService :IClientService

    {
        private IClientRepository _repository;
        private readonly IFileService _fileService;
        public ClientService(IClientRepository repository ,IFileService fileService)
        {
            _repository = repository;
            _fileService = fileService;
        }

        public async Task<List<ClientDto>> GetAllAsync()
        {
            var clients = await _repository.GetAllWithIncludesAsync();

            return clients.Select(c => new ClientDto
            {
                Id = c.Id,
                FullName = c.User?.FullName,
                Email = c.User?.Email,
                Phone  = c.User?.PhoneNumber,
                Address = c.User?.Address,
                IsActive = c.User?.IsActive ?? false,
                OrdersIds = c.Orders?.Select(o => o.Id).ToList() ?? new(),
                SubscriptionIds = c.Subscriptions?.Select(s => s.Id).ToList() ?? new()
            }).ToList();
        }

        public async Task<ClientDto> GetByIdAsync(int id)
        {
            var client = await _repository.GetByIdWithIncludesAsync(id);

            if (client == null)
                throw new NotFoundException("Client not found");

            return new ClientDto
            {
                Id = client.Id,
                FullName = client.User?.FullName,
                Email = client.User?.Email,
                Phone = client.User?.PhoneNumber,
                Address = client.User?.Address,
                IsActive = client.User?.IsActive ?? false,
                OrdersIds = client.Orders?.Select(o => o.Id).ToList() ?? new(),
                SubscriptionIds = client.Subscriptions?.Select(s => s.Id).ToList() ?? new()
            };
        }

        public async Task UpdateAsync(int id, ClientUpdateDto dto)
        {
            var client = await _repository.GetByIdWithIncludesAsync(id);

            if (client == null)
                throw new NotFoundException("Client not found");

            client.User.FullName = dto.FullName;

            if (dto.ProfilePicture != null)
            {
                if (!string.IsNullOrWhiteSpace(client.ProfilePicture))
                {
                    var oldPath = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot",
                        client.ProfilePicture.TrimStart('/')
                    );

                    if (System.IO.File.Exists(oldPath))
                        System.IO.File.Delete(oldPath);
                }

                var newPath = await _fileService.UploadFileAsync(dto.ProfilePicture, "images/clients");

                client.ProfilePicture = newPath;
            }

            _repository.Update(client);
            await _repository.SaveAsync();
        }

        public async Task SetClientActiveStatus(int clientId, bool isActive)
        {
            var client = await _repository.GetByIdWithIncludesAsync(clientId);

            if (client == null)
                throw new NotFoundException("Client not found");

            client.User.IsActive = isActive;

            _repository.Update(client);
            await _repository.SaveAsync();
        }


        public async Task DeleteAsync(int id)
        {
            var client = await _repository.GetByIdWithIncludesAsync(id);

            if (client == null)
                throw new NotFoundException("Client not found");

            await _repository.DeleteAsync(client);
            await _repository.SaveAsync();
        }

        public async Task<List<ClientDto>> SearchAsync(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                throw new BadRequestException("Search keyword is required");

            var clients = await _repository.SearchAsync(keyword);

            if (!clients.Any())
                throw new NotFoundException("No clients found");

            return clients.Select(c => new ClientDto
            {
                Id = c.Id,
                FullName = c.User?.FullName,
                Email = c.User?.Email,
                Phone = c.User?.PhoneNumber,
                Address = c.User?.Address,
                IsActive = c.User?.IsActive ?? false,
                OrdersIds = c.Orders?.Select(o => o.Id).ToList() ?? new(),
                SubscriptionIds = c.Subscriptions?.Select(s => s.Id).ToList() ?? new()
            }).ToList();
        }

        public override bool Equals(object? obj)
        {
            return obj is ClientService service &&
                   EqualityComparer<IClientRepository>.Default.Equals(_repository, service._repository);
        }
    }
}
