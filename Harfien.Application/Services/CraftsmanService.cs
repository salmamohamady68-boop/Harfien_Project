using Harfien.Application.DTO;
using Harfien.Application.DTO.Profile_Craftman;
using Harfien.Application.DTO.Review;
using Harfien.Application.Exceptions;
using Harfien.Application.Interfaces;
using Harfien.Domain.Entities;
using Harfien.Domain.Enums;
using Harfien.Domain.Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Harfien.Application.Services
{
    public class CraftsmanService : ICraftsmanService
    {
        private readonly ICraftsmanRepository _repository;
        private readonly IReviewRepository _reviewRepository;

        public CraftsmanService(ICraftsmanRepository repository, IReviewRepository reviewRepository)
        {
            _repository = repository;
            _reviewRepository = reviewRepository;
        }

        public async Task<GetMyProfileDto?> GetMyProfileAsync(string userId)
        {
            var craftsman = await _repository.GetByUserIdWithIncludeAsync(userId);

            if (craftsman == null)
                return null;

            return new GetMyProfileDto
            {
                Id = craftsman.Id,
                FullName = craftsman.User?.FullName,
                PhoneNumber = craftsman.User?.PhoneNumber,
                Bio = craftsman.Bio,
                YearsOfExperience = craftsman.YearsOfExperience,
                IsVerified = craftsman.IsApproved,



                Services = craftsman.CraftsmanServices?
                    .Select(s => new ServiceDto
                    {
                        Id=s.Id,
                        Name = s.Name,
                        Price = s.Price
                    }).ToList() ?? new List<ServiceDto>(),

                Availabilities = craftsman.Availabilities?
                    .Where(a => a.IsAvailable)
                    .Select(a => new AvailabilityDto
                    {
                        Day = a.Day,
                        From = a.From,
                        To = a.To
                    }).ToList() ?? new List<AvailabilityDto>()
            };
        }

        public async Task<CraftsmanProfileDto?> GetProfileAsync(int id)
        {
            var craftsman = await _repository.GetProfileAsync(id);

            if (craftsman == null)
                return null;

            var reviews = await _repository.GetReviewAsync(id);

            var averageRating = reviews.Any()
                ? reviews.Average(r => r.Rating)
                : 0;

            return new CraftsmanProfileDto
            {
                Id = craftsman.Id,
                FullName = craftsman.User?.FullName,
                Bio = craftsman.Bio,
                YearsOfExperience = craftsman.YearsOfExperience,
                IsVerified = craftsman.IsApproved,
                Rating = Math.Round(averageRating, 1),

                Services = craftsman.CraftsmanServices?
                    .Select(s => new ServiceDto
                    {
                        Id=s.Id,
                        Name = s.Name,
                        Price = s.Price
                    }).ToList() ?? new List<ServiceDto>(),

                Availabilities = craftsman.Availabilities?
                    .Where(a => a.IsAvailable)
                    .Select(a => new AvailabilityDto
                    {
                        Day = a.Day,
                        From = a.From,
                        To = a.To
                    }).ToList() ?? new List<AvailabilityDto>(),

                Reviews = reviews?
                    .Select(r => new ReviewsDto
                    {
                        Rating = r.Rating,
                        Comment = r.Comment
                    }).ToList() ?? new List<ReviewsDto>(),

                CompletedOrdersCount = craftsman.Orders?
                    .Count(o => o.Status == OrderStatus.Completed) ?? 0
            };
        }

        public async Task UpdateMyProfileAsync(string userId, UpdateMyProfileDto dto)
        {
            var craftsman = await _repository.GetByUserIdWithIncludeAsync(userId);

            if (craftsman == null)
                throw new NotFoundException("Craftsman not found");

            if (!string.IsNullOrWhiteSpace(dto.Bio))
                craftsman.Bio = dto.Bio;

            if (dto.YearsOfExperience.HasValue)
                craftsman.YearsOfExperience = dto.YearsOfExperience.Value;

            if (!string.IsNullOrWhiteSpace(dto.FullName))
                craftsman.User.FullName = dto.FullName;

            if (!string.IsNullOrWhiteSpace(dto.PhoneNumber))
                craftsman.User.PhoneNumber = dto.PhoneNumber;

            if (dto.Services != null && dto.Services.Any())
            {
                foreach (var serviceDto in dto.Services)
                {
                    var existingService = craftsman.CraftsmanServices?
                        .FirstOrDefault(s => s.Id == serviceDto.Id);

                    if (existingService == null)
                        throw new NotFoundException($"Service with Id {serviceDto.Id} not found for this craftsman");

                    existingService.Name = serviceDto.Name;
                    existingService.Price = serviceDto.Price;
                }
            }

            await _repository.SaveAsync();
        }
        public async Task<List<CraftsmanDto>> GetAllAsync()
        {
            var craftsmen = await _repository.GetAllWithUserAsync();

            return craftsmen.Select(c => new CraftsmanDto
            {
                Id = c.Id,
                FullName = c.User?.FullName,
                Bio = c.Bio,
                PhoneNumber = c.User?.PhoneNumber,
                Email = c.User?.Email,
                AreaName = c.User?.Area?.Name,
                CityName = c.User?.Area?.City?.Name,
                Rating = c.Rating,
                YearsOfExperience = c.YearsOfExperience,
                IsVerified = c.IsApproved,

                Services = c.CraftsmanServices?
                    .Select(s => new ServiceDto
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Price = s.Price,
                        ServiceCategoreyName = s.ServiceCategory?.Name
                    }).ToList() ?? new List<ServiceDto>(),

                Availabilities = c.Availabilities?
                    .Where(a => a.IsAvailable)
                    .Select(a => new AvailabilityDto
                    {
                        Day = a.Day,
                        From = a.From,
                        To = a.To
                    }).ToList() ?? new List<AvailabilityDto>(),

                Reviews = _reviewRepository.GetAllByCraftsmanIdAsync(c.Id).Result?
                    .Select(r => new GetReviewDto
                    {
                        Id = r.Id,
                        CreatedAt = DateOnly.FromDateTime(r.CreatedAt),
                        ClientName = r.Order.Client?.User?.FullName ?? "Unknown User",
                        Rating = r.Rating,
                        Comment = r.Comment
                    }).ToList() ?? new List<GetReviewDto>(),

                CompletedOrdersCount = c.Orders?
                    .Count(o => o.Status == OrderStatus.Completed) ?? 0
            }).ToList();
        }
    }
}