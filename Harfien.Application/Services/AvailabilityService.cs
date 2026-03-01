using Harfien.Application.DTO.CraftsmanAvailiability;
using Harfien.Application.DTO.Error;
using Harfien.Application.Interfaces;
using Harfien.Domain.Entities;
using Harfien.Domain.Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

    // ==========================================
    // ✅ Add Availability (ترجع DTO)
    // ==========================================
    public async Task<AvailabilityreadDto?> AddAvailabilityAsync(
        CreateAvailabilityDto dto,
        string userId,
        List<FieldErrorDto> serviceErrors)
    {
        var craftsman = await _craftsmanRepository.GetByUserIdAsync(userId);
        if (craftsman == null)
        {
            serviceErrors.Add(new FieldErrorDto { Field = "Craftsman", Message = "Craftsman not found" });
            return null;
        }

        // Validation
        if (dto.StartTime >= dto.EndTime)
            serviceErrors.Add(new FieldErrorDto { Field = "StartTime", Message = "Start time must be earlier than end time" });

        if (dto.EndTime == TimeSpan.Zero)
            serviceErrors.Add(new FieldErrorDto { Field = "EndTime", Message = "End time cannot be 00:00" });

        var existing = await _availabilityRepository.GetAllByCraftsmanIdAsync(craftsman.Id);
        if (existing.Any(a => a.Day == dto.Day))
            serviceErrors.Add(new FieldErrorDto { Field = "Day", Message = "Availability already exists for this day" });

        if (serviceErrors.Any())
            return null;

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

        // رجع DTO بدل الـ Entity
        return new AvailabilityreadDto
        {
            CraftsmanId = availability.CraftsmanId,
            Day = availability.Day,
            StartTime = availability.From,
            EndTime = availability.To,
            IsAvailable = availability.IsAvailable
        };
    }

    // ==========================================
    // ✅ Get Availability
    // ==========================================
    public async Task<IEnumerable<AvailabilityreadDto>> GetCraftsmanAvailabilityAsync(int craftsmanId)
    {
        var availabilities = await _availabilityRepository.GetAllByCraftsmanIdAsync(craftsmanId);

        return availabilities
            .Where(a => a.IsAvailable)
            .Select(a => new AvailabilityreadDto
            {
                CraftsmanId = a.CraftsmanId,
                Day = a.Day,
                StartTime = a.From,
                EndTime = a.To,
                IsAvailable = a.IsAvailable
            });
    }

    // ==========================================
    // ✅ Update My Availability (ترجع DTO)
    // ==========================================
    public async Task<AvailabilityreadDto?> UpdateMyAvailabilityAsync(
        List<CreateAvailabilityDto> dtos,
        string userId,
        List<FieldErrorDto> serviceErrors)
    {
        var craftsman = await _craftsmanRepository.GetByUserIdAsync(userId);
        if (craftsman == null)
        {
            serviceErrors.Add(new FieldErrorDto { Field = "Craftsman", Message = "Craftsman not found" });
            return null;
        }

        var existingAvailabilities = await _availabilityRepository.GetAllByCraftsmanIdAsync(craftsman.Id);

        CraftsmanAvailability? lastUpdated = null;

        foreach (var dto in dtos)
        {
            // Validation
            if (dto.StartTime >= dto.EndTime)
            {
                serviceErrors.Add(new FieldErrorDto { Field = "StartTime", Message = "Start time must be earlier than end time" });
                continue;
            }

            if (dto.EndTime == TimeSpan.Zero)
            {
                serviceErrors.Add(new FieldErrorDto { Field = "EndTime", Message = "End time cannot be 00:00" });
                continue;
            }

            var availability = existingAvailabilities.FirstOrDefault(a => a.Day == dto.Day);

            if (availability != null)
            {
                availability.From = dto.StartTime;
                availability.To = dto.EndTime;
                availability.IsAvailable = dto.IsAvailable;

                _availabilityRepository.Update(availability);
                lastUpdated = availability;
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
                lastUpdated = newAvailability;
            }
        }

        if (!serviceErrors.Any() && lastUpdated != null)
            await _availabilityRepository.SaveAsync();

        // رجع DTO بدل Entity
        return lastUpdated == null ? null : new AvailabilityreadDto
        {
            CraftsmanId = lastUpdated.CraftsmanId,
            Day = lastUpdated.Day,
            StartTime = lastUpdated.From,
            EndTime = lastUpdated.To,
            IsAvailable = lastUpdated.IsAvailable
        };
    }
}