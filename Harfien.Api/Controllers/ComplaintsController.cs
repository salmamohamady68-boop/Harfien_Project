using Harfien.Application.DTO.Complaint;
using Harfien.Application.Interfaces;
using Harfien.Domain.Enums;
using Harfien.Domain.Shared.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Harfien.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplaintsController : ControllerBase
    {
        private readonly IComplaintService _service;
        private readonly IUnitOfWork _unit;

        public ComplaintsController(IComplaintService service, IUnitOfWork unit)
        {
            _service = service;
            _unit = unit;
        }

        #region Client

        [Authorize(Roles = "Client")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateComplaintDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { success = false, message = "Invalid data", errors = ModelState });

            int reporterId = await GetClientIdSafe();

            var result = await _service.CreateComplaintAsync(reporterId, dto);

            return Ok(new
            {
                success = true,
                message = "Complaint created successfully",
                data = result
            });
        }

        [Authorize(Roles = "Client")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateComplaintDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { success = false, message = "Invalid data", errors = ModelState });

            int reporterId = await GetClientIdSafe();

            var result = await _service.UpdateComplaintAsync(reporterId, id, dto);

            return Ok(new
            {
                success = true,
                message = "Complaint updated successfully",
                data = result
            });
        }

        [Authorize(Roles = "Client")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int reporterId = await GetClientIdSafe();

            var result = await _service.DeleteComplaintAsync(reporterId, id);

            return Ok(new
            {
                success = true,
                message = "Complaint deleted successfully",
                data = result
            });
        }

        [Authorize(Roles = "Client")]
        [HttpGet("my")]
        public async Task<IActionResult> GetMy()
        {
            int reporterId = await GetClientIdSafe();
            var data = await _service.GetMyComplaintsAsync(reporterId);

            return Ok(new
            {
                success = true,
                data = data
            });
        }

        [Authorize(Roles = "Client, Craftsman")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            int userId = await GetUserIdSafe();
            var data = await _service.GetComplaintByIdAsync(userId, id);

            return Ok(new
            {
                success = true,
                data = data
            });
        }

        #endregion

        [Authorize(Roles = "Craftsman")]
        [HttpGet("issued-complaints")]
        public async Task<IActionResult> GetComplaintsIssuedForCraftsman()
        {
            int craftsmanId = await GetCraftsmanIdSafe();
            var data = await _service.GetComplaintsIssuedForCraftsmanAsync(craftsmanId);

            return Ok(new
            {
                success = true,
                data
            });
        }

        #region Admin

        [Authorize(Roles = "Admin")]
        [HttpGet("admin")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAllComplaintsAsync();

            return Ok(new
            {
                success = true,
                data = data
            });
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("admin/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var data = await _service.GetComplaintDetailsAsync(id);

            return Ok(new
            {
                success = true,
                data = data
            });
        }

        [Authorize(Roles = "Admin")]
        [HttpPatch("admin/{id}/status")]
        public async Task<IActionResult> ChangeStatus(int id, [FromQuery] ComplaintStatus status)
        {
            var result = await _service.ChangeStatusAsync(id, status);

            return Ok(new
            {
                success = true,
                message = "Status updated successfully",
                data = result
            });
        }

        [Authorize(Roles = "Admin")]
        [HttpPatch("admin/{id}/resolution")]
        public async Task<IActionResult> Resolution(int id, [FromBody] string notes)
        {
            if (string.IsNullOrWhiteSpace(notes))
                return BadRequest(new { success = false, message = "Resolution notes cannot be empty" });

            var result = await _service.AddResolutionAsync(id, notes);

            return Ok(new
            {
                success = true,
                message = "Complaint resolved successfully",
                data = result
            });
        }

        #endregion

        #region Helpers

        private async Task<int> GetUserIdSafe()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                throw new UnauthorizedAccessException("User not authenticated");

            var craftsman = await _unit.Craftsmen.GetByUserIdAsync(userId);
            if (craftsman != null)
                return craftsman.Id;

            var client = await _unit.Clients.GetByUserIdAsync(userId);
            if (client != null)
                return client.Id;

            throw new UnauthorizedAccessException("User is not linked to Client or Craftsman");
        }

        private async Task<int> GetClientIdSafe()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                throw new UnauthorizedAccessException("User not authenticated");

            var client = await _unit.Clients.GetByUserIdAsync(userId);
            if (client != null)
                return client.Id;

            throw new UnauthorizedAccessException("User is not linked to Client");
        }
        private async Task<int> GetCraftsmanIdSafe()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                throw new UnauthorizedAccessException("User not authenticated");

            var craftsman = await _unit.Craftsmen.GetByUserIdAsync(userId);
            if (craftsman != null)
                return craftsman.Id;

            throw new UnauthorizedAccessException("User is not linked to Craftsman");
        }

        #endregion
    }
}