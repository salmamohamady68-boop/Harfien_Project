using Harfien.Application.DTO.Profile_Craftman;
using Harfien.Application.Exceptions;
using Harfien.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Harfien.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CraftsmenController : ControllerBase
    {
        private readonly ICraftsmanService _service;

        public CraftsmenController(ICraftsmanService service)
        {
            _service = service;
        }

        private string GetBaseUrl() => $"{Request.Scheme}://{Request.Host}";

        private string? FullImageUrl(string? relativePath) =>
            string.IsNullOrWhiteSpace(relativePath) ? null : $"{GetBaseUrl()}/{relativePath.TrimStart('/')}";

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            foreach (var craftsman in result)
                craftsman.ProfilePicture = FullImageUrl(craftsman.ProfilePicture);
            return Ok(result);
        }

        [HttpGet("{id}/profile")]
        public async Task<IActionResult> GetProfile(int id)
        {
            var result = await _service.GetProfileAsync(id);
            if (result == null) throw new NotFoundException("Craftsman not found");
            result.ProfilePicture = FullImageUrl(result.ProfilePicture);
            return Ok(result);
        }

        [HttpGet("me")]
        [Authorize(Roles = "Craftsman")]
        public async Task<IActionResult> GetMyProfile()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = await _service.GetMyProfileAsync(userId);
            if (result == null) throw new NotFoundException("Profile not found");
            result.ProfilePicture = FullImageUrl(result.ProfilePicture);
            return Ok(result);
        }

        [HttpPut("me")]
        [Authorize(Roles = "Craftsman")]
        public async Task<IActionResult> UpdateMyProfile([FromForm] UpdateMyProfileDto dto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await _service.UpdateMyProfileAsync(userId, dto);

            var updatedProfile = await _service.GetMyProfileAsync(userId);
            updatedProfile.ProfilePicture = FullImageUrl(updatedProfile.ProfilePicture);

            return Ok(updatedProfile);
        }
    }
}