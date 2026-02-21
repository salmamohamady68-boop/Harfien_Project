using Harfien.Application.DTO.Order;
using Harfien.Application.Interfaces;
using Harfien.Domain.Entities;
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

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderDto dto)
        {
            // 1️⃣ جلب الـ UserId من الـ Claims
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            // 2️⃣ التحقق من وجود قيمة وتحويلها لـ int
            if (string.IsNullOrEmpty(userIdString) || !int.TryParse(userIdString, out int clientId))
                return BadRequest("Invalid client id");

            // 3️⃣ إنشاء الأوردر باستخدام الـ service وتمرير الـ clientId الصحيح
            await _service.CreateAsync(dto, clientId);

            // 4️⃣ إعادة رسالة نجاح
            return Ok("Order created successfully");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _service.GetByIdAsync(id);
            return Ok(order);
        }

        // ===========================
        // Get Client Orders
        // ===========================
        [HttpGet("client")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> GetClientOrders()
        {
            var clientId = int.Parse(User.FindFirst("id")!.Value);

            var orders = await _service.GetClientOrdersAsync(clientId);
            return Ok(orders);
        }

        [HttpGet("craftsman")]
        [Authorize(Roles = "Craftsman")]
        public async Task<IActionResult> GetCraftsmanOrders()
        {
            var craftsmanId = int.Parse(User.FindFirst("id")!.Value);

            var orders = await _service.GetCraftsmanOrdersAsync(craftsmanId);
            return Ok(orders);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _service.GetAllAsync();
            return Ok(orders);
        }

        // ===========================
        // Get By Status
        // ===========================
        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetByStatus(OrderStatus status)
        {
            var orders = await _service.GetByStatusAsync(status);
            return Ok(orders);
        }

        // ===========================
        // Accept Order
        // ===========================
        [HttpPut("{id}/accept")]
        [Authorize(Roles = "Craftsman")]
        public async Task<IActionResult> Accept(int id)
        {
            var craftsmanId = int.Parse(User.FindFirst("id")!.Value);

            await _service.AcceptAsync(id, craftsmanId);
            return NoContent();
        }

        // ===========================
        // Reject Order
        // ===========================
        [HttpPut("{id}/reject")]
        [Authorize(Roles = "Craftsman")]
        public async Task<IActionResult> Reject(int id)
        {
            var craftsmanId = int.Parse(User.FindFirst("id")!.Value);

            await _service.RejectAsync(id, craftsmanId);
            return NoContent();
        }

        // ===========================
        // Start Order
        // ===========================
        [HttpPut("{id}/start")]
        [Authorize(Roles = "Craftsman")]
        public async Task<IActionResult> Start(int id)
        {
            var craftsmanId = int.Parse(User.FindFirst("id")!.Value);

            await _service.StartAsync(id, craftsmanId);
            return NoContent();
        }

        // ===========================
        // Complete Order
        // ===========================
        [HttpPut("{id}/complete")]
        [Authorize(Roles = "Craftsman")]
        public async Task<IActionResult> Complete(int id)
        {
            var craftsmanId = int.Parse(User.FindFirst("id")!.Value);

            await _service.CompleteAsync(id, craftsmanId);
            return NoContent();
        }

        // ===========================
        // Cancel Order
        // ===========================
        [HttpPut("{id}/cancel")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> Cancel(int id)
        {
            var clientId = int.Parse(User.FindFirst("id")!.Value);

            await _service.CancelAsync(id, clientId);
            return NoContent();

        }
    }
}