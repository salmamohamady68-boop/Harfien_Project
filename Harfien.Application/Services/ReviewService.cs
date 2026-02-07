using Harfien.Application.DTOs;
using Harfien.Application.Interfaces;
using Harfien.Domain.Entities;
using Harfien.Domain.Enums;
using Harfien.Domain.Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harfien.Application.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ICraftsmanRepository _craftsmanRepository;
        public ReviewService(IReviewRepository reviewRepository, IOrderRepository orderRepository, ICraftsmanRepository craftsmanRepository)
        {
            _reviewRepository = reviewRepository;
            _orderRepository = orderRepository;
            _craftsmanRepository = craftsmanRepository;
        }

        public async Task<ReviewDto> AddReviewAsync(CreateReviewDto dto, int currentUserId)
        {
            var order = await _orderRepository.GetByIdAsync(dto.OrderId);

            if (order == null) throw new Exception("Order not found.");

            if (order.Client.User.Id != currentUserId) throw new Exception("You are not authorized to review this order.");// need to be fixed

            if (order.Status != OrderStatus.Complete) throw new Exception("You can only review completed orders.");



            //// Fast, clean, returns specific message
            //if (await _reviewRepository.HasReviewForOrderAsync(order.Id))
            //    throw new BusinessException("You already reviewed this order.");



            var review = new Review
            {
                OrderId = order.Id,
                Rating = dto.Rating,
                Comment = dto.Comment,
                ClientId = order.ClientId,
                CraftsmanId = order.CraftsmanId,
                CreatedAt = DateTime.UtcNow
            };

            await _reviewRepository.AddAsync(review);

            var craftsman = await _craftsmanRepository.GetByIdAsync(order.CraftsmanId);
            if (craftsman != null)
            {
                var currentRating = craftsman.Rating;
                var existingReviews = await _reviewRepository.GetAllByCraftsmanIdAsync(order.CraftsmanId);
                int oldCount = existingReviews.Count;

                // Calculate new average: ((OldAvg * OldCount) + NewRating) / (OldCount + 1)
                double newTotalScore = (currentRating * oldCount) + dto.Rating;
                double newAverage = newTotalScore / (oldCount + 1);

                craftsman.Rating = Math.Round(newAverage, 2);

                _craftsmanRepository.Update(craftsman);
            }

            // could use unit of work for avoding confusion
            // This saves the Review AND the Craftsman update in a single transaction.
            await _reviewRepository.SaveAsync();

            var createdReview = await _reviewRepository.GetByIdAsync(review.Id);
            if (createdReview == null) throw new Exception("Failed to create review.");

            return new ReviewDto
            {
                Id = review.Id,
                Rating = review.Rating,
                Comment = review.Comment,
                ClientName = createdReview.Order?.Client?.User?.FullName ?? "Unknown User"
            };
        }
        public async Task<List<ReviewDto>> GetReviewsByCraftsmanIdAsync(int craftsmanId)
        {
            var reviews = await _reviewRepository.GetAllByCraftsmanIdAsync(craftsmanId);

            // Map Entity to DTO
            return reviews.Select(r => new ReviewDto
            {
                Id = r.Id,
                ClientName = r.Order?.Client?.User?.FullName ?? "Unknown User",
                Rating = r.Rating,
                Comment = r.Comment,
                CreatedAt = r.CreatedAt
            }).ToList();
        }
    }
}
