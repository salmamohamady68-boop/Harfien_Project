using Harfien.Application.DTO;
using Harfien.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Harfien.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthservice _authService;  // <--- متوافق مع الاسم اللي عندك

        public AuthenticationController(IAuthservice authService)
        {
            _authService = authService;
        }

        // ==========================
        // Confirm Password
        // ==========================
        [HttpPost("confirm-password")]
        [Authorize] // لازم يكون المستخدم مسجل دخول
        public async Task<IActionResult> ConfirmPassword([FromBody] ConfirmPasswordDto request)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
                return Unauthorized();

            var result = await _authService.ConfirmPasswordAsync(userId, request.Password);

            if (!result)
                return BadRequest(new { message = "Password is incorrect" });

            return Ok(new { message = "Password confirmed successfully" });
        }

        // ==========================
        // Verify Reset Code
        // ==========================
        [HttpPost("verify-reset-code")]
        public async Task<IActionResult> VerifyResetCode([FromBody] VerifyResetCodeDto request)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
                return Unauthorized();

            var result = await _authService.VerifyResetCodeAsync(userId, request.ResetCode);

            if (!result)
                return BadRequest(new { message = "Invalid or expired reset code" });

            return Ok(new { message = "Reset code verified successfully" });
        }
    }
}
