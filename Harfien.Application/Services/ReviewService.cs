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
        // Add UnitOfWork if you use it

        public ReviewService(IReviewRepository reviewRepository, IOrderRepository orderRepository)
        {
            _reviewRepository = reviewRepository;
            _orderRepository = orderRepository;
        }

        public async Task<ReviewDto> AddReviewAsync(CreateReviewDto dto, int currentUserId)
        {
            var order = await _orderRepository.GetByIdAsync(dto.OrderId);

            if (order == null)
                throw new Exception("Order not found.");

            if (order.ClientId != currentUserId)
                throw new Exception("You are not authorized to review this order.");

            if (order.Status != OrderStatus.Complete)
                throw new Exception("You can only review completed orders.");

            // Duplicate Check: Check if review already exists for this order
            // (You'd likely implement a specific method in repo for this: _reviewRepository.ExistsByOrderId(id))

            // 3. Mapping (Here we satisfy your teammate's optimization request)
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
            await _reviewRepository.SaveAsync(); // Save to get the generated ID

            // 5. Return DTO
            return new ReviewDto
            {
                Id = review.Id,
                Rating = review.Rating,
                Comment = review.Comment
            };
        }
    }
}
