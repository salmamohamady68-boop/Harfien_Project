using Harfien.Application.DTOs;
using Harfien.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Harfien.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Harfien.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> Create([FromBody] CreateReviewDto dto)
        {
            // getting UserID from JWT Token
             //var userId = int.Parse(User.FindFirst("uid")?.Value);
             var userId = int.Parse(User.FindFirst("NameIdentifier")?.Value);idk
            //var userId = 10; // Mocking logged in user

            try
            {
                var result = await _reviewService.AddReviewAsync(dto, userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("craftsman/{craftsmanId}")]
        public async Task<IActionResult> GetCraftsmanReviews(int craftsmanId)
        {
            var reviews = await _reviewService.GetReviewsByCraftsmanIdAsync(craftsmanId);
            return Ok(reviews);
        }
    }
}
