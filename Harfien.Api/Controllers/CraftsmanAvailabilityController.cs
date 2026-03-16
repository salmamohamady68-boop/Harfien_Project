using Harfien.Application.DTO.CraftsmanAvailiability;
using Harfien.Application.DTO.Error;
using Harfien.Application.Helpers;
using Harfien.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CraftsmanAvailabilityController : ControllerBase
{
    private readonly IAvailabilityService _availabilityService;

    public CraftsmanAvailabilityController(IAvailabilityService availabilityService)
    {
        _availabilityService = availabilityService;
    }

    private string GetUserId() =>
        User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

    // ================= GET CRAFTSMAN AVAILABILITY =================
    [HttpGet("{craftsmanId}")]
    [Authorize(Roles = "Client,Craftsman")]
    public async Task<IActionResult> GetCraftsmanAvailability(int craftsmanId)
    {
        var availability =
            await _availabilityService.GetCraftsmanAvailabilityAsync(craftsmanId);

        if (!availability.Any())
            return NotFound("No availability found");

        return Ok(availability);
    }

    // ================= ADD AVAILABILITY =================
    [HttpPost]
    [Authorize(Roles = "Craftsman")]
    public async Task<IActionResult> AddAvailability(
        [FromBody] CreateAvailabilityDto dto)
    {
        var errors = new List<FieldErrorDto>();
        var userId = GetUserId();

        var result =
            await _availabilityService.AddAvailabilityAsync(dto, userId, errors);

        if (errors.Any())
            return ErrorHelper.HandleErrors(this, errors, "Failed to add availability");

        return Ok(result);
    }

    // ================= UPDATE AVAILABILITY =================
    [HttpPut]
    [Authorize(Roles = "Craftsman")]
    public async Task<IActionResult> UpdateAvailability(
        [FromBody] List<CreateAvailabilityDto> dtos)
    {
        var errors = new List<FieldErrorDto>();
        var userId = GetUserId();

        var result =
            await _availabilityService.UpdateMyAvailabilityAsync(dtos, userId, errors);

        if (errors.Any())
            return ErrorHelper.HandleErrors(this, errors, "Failed to update availability");

        return Ok(result);
    }
}