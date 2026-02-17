using Harfien.Application.DTO;
using Harfien.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class CraftsmanAvailabilityController : ControllerBase
{
    private readonly IAvailabilityService _availabilityService;

    public CraftsmanAvailabilityController(IAvailabilityService availabilityService)
    {
        _availabilityService = availabilityService;
    }

    [HttpGet]
    public async Task<IActionResult> GetMyAvailability()
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        var availability = await _availabilityService.GetMyAvailabilityAsync(userId);
        return Ok(availability);
    }

    [HttpPost]
    public async Task<IActionResult> AddAvailability([FromBody] CreateAvailabilityDto dto)
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        await _availabilityService.AddAvailabilityAsync(dto, userId);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAvailability([FromBody] List<CreateAvailabilityDto> dtos)
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        await _availabilityService.UpdateMyAvailabilityAsync(dtos, userId);
        return Ok();
    }
}

