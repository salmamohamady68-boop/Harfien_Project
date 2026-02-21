using Harfien.Application.DTO.CraftsmanAvailiability;
using Harfien.Application.Interfaces;
using Harfien.Domain.Entities;
using Harfien.Domain.Shared.Repositories;

public class AvailabilityService : IAvailabilityService
{
    private readonly IAvailabilityRepository _availabilityRepository;
    private readonly ICraftsmanRepository _craftsmanRepository;

    public AvailabilityService(
        IAvailabilityRepository availabilityRepository,
        ICraftsmanRepository craftsmanRepository)
    {
        _availabilityRepository = availabilityRepository;
        _craftsmanRepository = craftsmanRepository;
    }

    public async Task AddAvailabilityAsync(CreateAvailabilityDto dto, string userId)
    {
        var craftsman = await _craftsmanRepository.GetByUserIdAsync(userId);
        if (craftsman == null) throw new Exception("Craftsman not found");

        var availability = new CraftsmanAvailability
        {
            CraftsmanId = craftsman.Id,
            Day = dto.Day,
            From = dto.StartTime,
            To = dto.EndTime,
            IsAvailable = dto.IsAvailable
        };

        await _availabilityRepository.AddAsync(availability);
        await _availabilityRepository.SaveAsync();
    }

    public async Task<IEnumerable<AvailabilityreadDto>> GetMyAvailabilityAsync(string userId)
    {
        var craftsman = await _craftsmanRepository.GetByUserIdAsync(userId);
        if (craftsman == null) throw new Exception("Craftsman not found");

        var availabilities = await _availabilityRepository.GetAllByCraftsmanIdAsync(craftsman.Id);


        return availabilities.Select(a => new AvailabilityreadDto
        {
            CraftsmanId = a.CraftsmanId,
            Day = a.Day,
            StartTime = a.From,
            EndTime = a.To,
            IsAvailable = a.IsAvailable
        });
    }

    public async Task UpdateMyAvailabilityAsync(List<CreateAvailabilityDto> dtos, string userId)
    {
        var craftsman = await _craftsmanRepository.GetByUserIdAsync(userId);
        if (craftsman == null) throw new Exception("Craftsman not found");

        var availabilities = await _availabilityRepository.GetAllByCraftsmanIdAsync(craftsman.Id);
        foreach (var dto in dtos)
        {
            var availability = availabilities.FirstOrDefault(a => a.Day == dto.Day);
            if (availability != null)
            {
                availability.From = dto.StartTime;
                availability.To = dto.EndTime;
                availability.IsAvailable = dto.IsAvailable;
                _availabilityRepository.Update(availability);
            }
            else
            {
                var newAvailability = new CraftsmanAvailability
                {
                    CraftsmanId = craftsman.Id,
                    Day = dto.Day,
                    From = dto.StartTime,
                    To = dto.EndTime,
                    IsAvailable = dto.IsAvailable
                };
                await _availabilityRepository.AddAsync(newAvailability);
            }
        }

        await _availabilityRepository.SaveAsync();
    }
}
