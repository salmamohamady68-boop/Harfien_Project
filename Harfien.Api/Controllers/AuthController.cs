using Harfien.Application.Dtos.Auth;
using Harfien.Application.Dtos.AuthDtos;
using Harfien.Application.DTO;
using Harfien.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Harfien.Domain.Interface_Repository.Services;

namespace Harfien.Presentation.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // ==========================
        // Register Client
        // ==========================
        [HttpPost("register-client")]
        public async Task<IActionResult> RegisterClient(RegisterClientDto dto)
        {
            var token = await _authService.RegisterClientAsync(dto);
            return Ok(new { token });
        }

        // ==========================
        // Register Craftsman
        // ==========================
        [HttpPost("register-craftsman")]
        public async Task<IActionResult> RegisterCraftsman(RegisterCraftsmanDto dto)
        {
            await _authService.RegisterCraftsmanAsync(dto);
            return Ok(new { message = "Waiting for approval" });
        }

        // ==========================
        // Login
        // ==========================
        [HttpPost("login")]
        public async Task<IActionResult> Login(loginDto dto)
        {
            var token = await _authService.LoginAsync(dto);
            if (token == null)
                return Unauthorized(new { message = "Invalid credentials or account not approved" });

            return Ok(new { token });
        }

        // ==========================
        // Approve Craftsman (Admin only)
        // ==========================
        [Authorize(Roles = "Admin")]
        [HttpPost("approve-craftsman/{id}")]
        public async Task<IActionResult> Approve(int id)
        {
            var token = await _authService.ApproveCraftsmanAsync(id);
            return Ok(new { token });
        }

        
    }
}
