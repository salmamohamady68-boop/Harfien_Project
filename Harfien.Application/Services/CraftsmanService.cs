using Harfien.Application.DTO.Profile_Craftman;
using Harfien.Application.DTO.Review;
using Harfien.Application.Interfaces;
using Harfien.Domain.Enums;
using Harfien.Domain.Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harfien.Application.Services
{
    public class CraftsmanService : ICraftsmanService
    {
        private readonly ICraftsmanRepository _repository;
    

        public CraftsmanService(ICraftsmanRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetMyProfileDto?> GetMyProfileAsync(string userId)
        {
            var craftsman = await _repository.GetByUserIdWithIncludeAsync(userId);  

            if (craftsman == null)
                return null;

            return new GetMyProfileDto
            {
                FullName = craftsman.User.FullName,
                PhoneNumber = craftsman.User.PhoneNumber,
                Bio = craftsman.Bio,
                YearsOfExperience = craftsman.YearsOfExperience,
                IsVerified = craftsman.IsVerified,

                Services = craftsman.CraftsmanServices
                    .Select(s => new ServiceDto
                    {
                        Name = s.Name,
                        Price = s.Price
                    }).ToList()
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
                FullName = craftsman.User.FullName,
                Bio = craftsman.Bio,
                YearsOfExperience = craftsman.YearsOfExperience,
                IsVerified = craftsman.IsVerified,
                Rating = Math.Round(averageRating, 1),

                Services = craftsman.CraftsmanServices
                    .Select(s => new ServiceDto
                    {
                        Name = s.Name,
                        Price = s.Price
                    }).ToList(),

                Availabilities = craftsman.Availabilities
                    .Where(a => a.IsAvailable)
                    .Select(a => new AvailabilityDto
                    {
                        Day = a.Day,
                        From = a.From,
                        To = a.To
                    }).ToList(),

                Reviews = reviews
                    .Select(r => new ReviewsDto
                    {
                        Rating = r.Rating,
                        Comment = r.Comment
                    }).ToList(),

                CompletedOrdersCount = craftsman.Orders
                    .Count(o => o.Status == OrderStatus.Complete)
            };
        }


        public async Task UpdateMyProfileAsync(string userId, UpdateMyProfileDto dto)
        {
            var craftsman = await _repository.GetByUserIdWithIncludeAsync(userId);

            if (craftsman == null)
                throw new Exception("Craftsman not found");


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
                    var existingService = craftsman.CraftsmanServices
                        .FirstOrDefault(s => s.Id == serviceDto.Id);

                    if (existingService == null)
                        throw new Exception($"Service with Id {serviceDto.Id} not found for this craftsman");

                    existingService.Name = serviceDto.Name;
                    existingService.Price = serviceDto.Price;
                }
            }

            await _repository.SaveAsync();
        }

        //public async Task UpdateMyProfileAsync(string userId, UpdateMyProfileDto dto)
        //{
        //    var craftsman = await _repository.GetByUserIdWithIncludeAsync(userId);

        //    if (craftsman == null)
        //        throw new Exception("Craftsman not found");

        //    craftsman.Bio = dto.Bio;
        //    craftsman.YearsOfExperience = dto;
        //    craftsman.User.FullName = dto.FullName;
        //    craftsman.User.PhoneNumber = dto.PhoneNumber;

        //    foreach (var serviceDto in dto.Services)
        //    {
        //        var existingService = craftsman.CraftsmanServices
        //            .FirstOrDefault(s => s.Id == serviceDto.Id);

        //        if (existingService == null)
        //            throw new Exception($"Service with Id {serviceDto.Id} not found for this craftsman");

        //        existingService.Name = serviceDto.Name;
        //        existingService.Price = serviceDto.Price;
        //    }

        //    await _repository.SaveAsync();
        //}
    }
}
