using Harfien.Application.DTO.Error;
using Harfien.Application.DTO.Order;
using Harfien.Application.Helpers;
using Harfien.Application.Interfaces;
using Harfien.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
namespace Harfien.Presentation.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;
        private readonly HarfienDbContext _context;

        public OrdersController(IOrderService service, HarfienDbContext context)
        {
            _service = service;
            _context = context;
        }

        private async Task<int> GetClientIdAsync()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var client = await _context.Clients.FirstOrDefaultAsync(c => c.UserId == userId);
            return client!.Id;
        }

        private async Task<int> GetCraftsmanIdAsync()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var craftsman = await _context.Craftsmen.FirstOrDefaultAsync(c => c.UserId == userId);
            return craftsman!.Id;
        }

        [HttpPost]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto dto)
        {
            var errors = new List<FieldErrorDto>();
            var clientId = await GetClientIdAsync();

            var result = await _service.CreateAsync(dto, clientId, errors);

            if (!ModelState.IsValid || errors.Any())
                return ErrorHelper.HandleErrors(this, errors, "Order creation failed");

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var errors = new List<FieldErrorDto>();

            var result = await _service.GetByIdAsync(id, errors);

            if (errors.Any())
                return ErrorHelper.HandleErrors(this, errors, "Get order failed", 404);

            return Ok(result);
        }

        [HttpGet("client")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> GetClientOrders()
        {
            var errors = new List<FieldErrorDto>();
            var clientId = await GetClientIdAsync();

            var result = await _service.GetClientOrdersAsync(clientId, errors);

            if (errors.Any())
                return ErrorHelper.HandleErrors(this, errors, "Client orders failed");

            return Ok(result);
        }

        [HttpGet("craftsman")]
        [Authorize(Roles = "Craftsman")]
        public async Task<IActionResult> GetCraftsmanOrders()
        {
            var errors = new List<FieldErrorDto>();
            var craftsmanId = await GetCraftsmanIdAsync();

            var result = await _service.GetCraftsmanOrdersAsync(craftsmanId, errors);

            if (errors.Any())
                return ErrorHelper.HandleErrors(this, errors, "Craftsman orders failed");

            return Ok(result);
        }

        [HttpPut("{id}/accept")]
        [Authorize(Roles = "Craftsman")]
        public async Task<IActionResult> Accept(int id)
        {
            var errors = new List<FieldErrorDto>();
            var craftsmanId = await GetCraftsmanIdAsync();

            await _service.AcceptAsync(id, craftsmanId, errors);

            if (errors.Any())
                return ErrorHelper.HandleErrors(this, errors, "Accept failed");

            return NoContent();
        }

        [HttpPut("{id}/reject")]
        [Authorize(Roles = "Craftsman")]
        public async Task<IActionResult> Reject(int id)
        {
            var errors = new List<FieldErrorDto>();
            var craftsmanId = await GetCraftsmanIdAsync();

            await _service.RejectAsync(id, craftsmanId, errors);

            if (errors.Any())
                return ErrorHelper.HandleErrors(this, errors, "Reject failed");

            return NoContent();
        }

        [HttpPut("{id}/start")]
        [Authorize(Roles = "Craftsman")]
        public async Task<IActionResult> Start(int id)
        {
            var errors = new List<FieldErrorDto>();
            var craftsmanId = await GetCraftsmanIdAsync();

            await _service.StartAsync(id, craftsmanId, errors);

            if (errors.Any())
                return ErrorHelper.HandleErrors(this, errors, "Start failed");

            return NoContent();
        }

        [HttpPut("{id}/complete")]
        [Authorize(Roles = "Craftsman")]
        public async Task<IActionResult> Complete(int id)
        {
            var errors = new List<FieldErrorDto>();
            var craftsmanId = await GetCraftsmanIdAsync();

            await _service.CompleteAsync(id, craftsmanId, errors);

            if (errors.Any())
                return ErrorHelper.HandleErrors(this, errors, "Complete failed");

            return NoContent();
        }

        [HttpPut("{id}/cancel")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> Cancel(int id)
        {
            var errors = new List<FieldErrorDto>();
            var clientId = await GetClientIdAsync();

            await _service.CancelAsync(id, clientId, errors);

            if (errors.Any())
                return ErrorHelper.HandleErrors(this, errors, "Cancel failed");

            return NoContent();
        }
    }
}