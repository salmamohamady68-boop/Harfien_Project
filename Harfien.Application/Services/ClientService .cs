using Harfien.Application.DTO;
using Harfien.Application.Exceptions;
using Harfien.Application.Interfaces;
using Harfien.Domain.Shared.Repositories;
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

        public ClientService(IClientRepository repository)
        {
            _repository = repository;
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
                OrdersIds = client.Orders?.Select(o => o.Id).ToList() ?? new(),
                SubscriptionIds = client.Subscriptions?.Select(s => s.Id).ToList() ?? new()
            };
        }

        public async Task UpdateAsync(int id, string fullName)
        {
            var client = await _repository.GetByIdWithIncludesAsync(id);

            if (client == null)
                throw new NotFoundException("Client not found");

            client.User.FullName = fullName;

            await _repository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var client = await _repository.GetByIdWithIncludesAsync(id);

            if (client == null)
                throw new NotFoundException("Client not found");

            await _repository.DeleteAsync(client);
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
