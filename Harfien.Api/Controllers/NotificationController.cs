using Harfien.Application.DTO.Notifications;
using Harfien.Application.Helpers;
using Harfien.Application.Interfaces;
using Harfien.Application.Services;
using Harfien.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Harfien.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]

    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;


        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetUserNotifications()
        {
           
            var userId = User.Claims.FirstOrDefault(c => c.Type.Contains("nameidentifier"))?.Value;
            if (userId == null)
                return Unauthorized();

            var notifications = await _notificationService.GetUserNotificationsDtoAsync(userId);
            return Ok(notifications);
        }



        [HttpPut("{id}/read")]
        [HttpPut("mark-as-read/{id}")]
        public async Task<IActionResult> MarkAsRead(int id)
        {
            var result = await _notificationService.MarkAsReadAsync(id);

            if (!result.IsSuccess)
            {
                return ErrorHelper.HandleErrors(
                    this,
                    result.Errors,
                    result.Message,
                    StatusCodes.Status404NotFound);
            }

            return Ok(new { message = result.Message });
        }
        [HttpPost("send")]
        public async Task<IActionResult> SendNotification([FromBody] NotificationRequestDto request)
        {
            if (string.IsNullOrEmpty(request.UserId) || string.IsNullOrEmpty(request.Title))
                return BadRequest("UserId and Title are required");

            try
            {
                
                await _notificationService.CreateNotificationAsync(request.UserId, request.Title, request.Message);

                
                var notification = new
                {
                    request.UserId,
                    request.Title,
                    request.Message,
                    CreatedAt = DateTime.UtcNow,
                    IsRead = false
                };

                return Ok(notification); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpPost("send-multiple")]
        public async Task<IActionResult> SendMultipleNotifications([FromBody] NotificationMultipleRequestDto request)
        {
            await _notificationService.SendToMultipleUsersAsync(request.UserIds, request.Title, request.Message);
            return Ok("Notifications sent successfully");
        }
    }
}

