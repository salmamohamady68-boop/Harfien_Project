using Harfien.Application.DTO;
using Harfien.Application.Interfaces;
using Harfien.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Harfien.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrdersController(IOrderService service)
        {
            _service = service;
        }

        //  Helper method to get current user ID from token
        private int GetCurrentUserId()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdClaim))
                throw new UnauthorizedAccessException("User not authenticated");

            return int.Parse(userIdClaim);
        }

        /// <summary>
        /// Create a new order (Client only)
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> Create([FromBody] CreateOrderDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var clientId = GetCurrentUserId();
                var orderId = await _service.CreateAsync(dto, clientId);
                return CreatedAtAction(nameof(Get), new { id = orderId }, new { orderId });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Get order by ID (Accessible by order owner or admin)
        /// </summary>
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var order = await _service.GetByIdAsync(id);

                // Authorization check
                var userId = GetCurrentUserId();
                var isAdmin = User.IsInRole("Admin");

                if (!isAdmin && order.ClientId != userId && order.CraftsmanId != userId)
                    return Forbid();

                return Ok(order);
            }
            catch (Exception ex)
            {
                return NotFound(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Get all orders for the current client
        /// </summary>
        [HttpGet("client/me")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> ClientOrders()
        {
            try
            {
                var clientId = GetCurrentUserId();
                var orders = await _service.GetClientOrdersAsync(clientId);
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Get all orders for the current craftsman
        /// </summary>
        [HttpGet("craftsman/me")]
        [Authorize(Roles = "Craftsman")]
        public async Task<IActionResult> CraftsmanOrders()
        {
            try
            {
                var craftsmanId = GetCurrentUserId();
                var orders = await _service.GetCraftsmanOrdersAsync(craftsmanId);
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Get all orders (Admin only)
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var orders = await _service.GetAllAsync();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Get orders by status (Admin only)
        /// </summary>
        [HttpGet("status/{status}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetByStatus(OrderStatus status)
        {
            try
            {
                var orders = await _service.GetByStatusAsync(status);
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Accept an order (Craftsman only)
        /// </summary>
        [HttpPut("{id}/accept")]
        [Authorize(Roles = "Craftsman")]
        public async Task<IActionResult> Accept(int id)
        {
            try
            {
                var craftsmanId = GetCurrentUserId();
                await _service.AcceptAsync(id, craftsmanId);
                return NoContent();
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Complete an order (Craftsman only)
        /// </summary>
        [HttpPut("{id}/complete")]
        [Authorize(Roles = "Craftsman")]
        public async Task<IActionResult> Complete(int id)
        {
            try
            {
                var craftsmanId = GetCurrentUserId();
                await _service.CompleteAsync(id, craftsmanId);
                return NoContent();
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Cancel an order (Client only)
        /// </summary>
        [HttpPut("{id}/cancel")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> Cancel(int id)
        {
            try
            {
                var clientId = GetCurrentUserId();
                await _service.CancelAsync(id, clientId);
                return NoContent();
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}