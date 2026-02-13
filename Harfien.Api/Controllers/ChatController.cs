using Harfien.Application.DTO;
using Harfien.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Harfien.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        // POST: api/chat
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] AddChatDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
                return Unauthorized();

            try
            {
                var chatId = await _chatService.CreateChatAsync(dto, userId);
                return Ok(chatId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/chat/order/5
        [HttpGet("order/{orderId}")]
        public async Task<IActionResult> GetByOrderId(int orderId)
        {
            var chat = await _chatService.GetByOrderIdAsync(orderId);
            return Ok(chat);
        }
    }
}


