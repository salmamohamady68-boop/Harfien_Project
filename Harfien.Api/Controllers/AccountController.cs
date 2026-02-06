using Harfien.Application.Dtos;
using Harfien.Domain.Dtos;
using Harfien.Domain.Entities;
using Harfien.Domain.Interface_Repository.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;




namespace Harfien.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailSender;
        private readonly IMemoryCache _cache;
        public AccountController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IEmailService emailSender, IMemoryCache cache)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _emailSender = emailSender;
            _cache = cache;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (!isValidEmail(model.Email))
            {
                return BadRequest(new { message = "Invalid email format." });
            }
            var existingUser = await _userManager.FindByEmailAsync(model.Email);
            if (existingUser != null)
            {
                return BadRequest(new { message = "Email already exists." });
            }

            var user = new ApplicationUser { 
                UserName = model.Email,
                Email = model.Email, 
                PhoneNumber = model.phoneNumber ,
                Address = model.Address,
                Fullname = model.Fullname,
                AreaId = model.AreaId,
                Zone = model.Zone,
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync("Client"))
                {
                    var roleResult = await _roleManager.CreateAsync(new IdentityRole("Client"));
                    if (!roleResult.Succeeded)
                    {
                        await _userManager.DeleteAsync(user);
                        return StatusCode(500, new { message = "User role creation failed.", errors = roleResult.Errors });
                    }
                }

                await _userManager.AddToRoleAsync(user, "Client");

                return Ok(new { message = "User registered successfully" });
            }

            var errors = result.Errors.Select(e => e.Description);
            return BadRequest(new { message = "Registration Failed.", errors });
        }




        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] TokenRequestModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Name, user.UserName!),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                    new Claim("userId", user.Id)
                };

                authClaims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    expires: DateTime.Now.AddMinutes(double.Parse(_configuration["Jwt:ExpiryMinutes"]!)),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!)),
                    SecurityAlgorithms.HmacSha256));

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }

            return Unauthorized();
        }
        [HttpPost("forget-Password")]
        public async Task<IActionResult> ForgetPassword([FromBody] ForgetPassword forgetPassword)
        {
            var user = await _userManager.FindByEmailAsync(forgetPassword.Email);

            if (user == null)
                return Ok(); // do not reveal user existence

            var code = Random.Shared.Next(10000, 100000).ToString(); // 5 digits

            user.ResetCode = BCrypt.Net.BCrypt.HashPassword(code);
            user.ResetCodeExpiry = DateTime.UtcNow.AddMinutes(10);

            await _userManager.UpdateAsync(user);

            await _emailSender.SendAsync(
                user.Email,
                "Password Reset Code",
                $"Your password reset code is: {code}\nThis code expires in 10 minutes."
            );

            return Ok("Reset code sent to your email");


        }

        [HttpPost("verify-reset-code")]
        public async Task<IActionResult> VerifyResetCode([FromBody] VerifyResetCode dto)
        {
          
            var user = _userManager.Users
                   .AsEnumerable()
                      .FirstOrDefault(u =>
            u.ResetCode != null &&
            BCrypt.Net.BCrypt.Verify(dto.Code, u.ResetCode));

            if (user == null)
                return BadRequest("Invalid code");

            if (user.ResetCodeExpiry < DateTime.UtcNow)
                return BadRequest("Code expired");

            // 🔥 store userId temporarily (10 minutes)
            _cache.Set("PasswordResetUser", user.Id, TimeSpan.FromMinutes(10));

            return Ok("Code verified");
        }






        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPassword dto)
        {
            if (!_cache.TryGetValue("PasswordResetUser", out string userId))
                return BadRequest("Verification expired");

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return BadRequest("User not found");

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var result = await _userManager.ResetPasswordAsync(user, token, dto.NewPassword);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            // cleanup
            _cache.Remove("PasswordResetUser");
            user.ResetCode = null;
            user.ResetCodeExpiry = null;
            await _userManager.UpdateAsync(user);

            return Ok("Password reset successfully");
        }


        private bool isValidEmail(string email)
        {
            try
            {
                var address = new System.Net.Mail.MailAddress(email);
                return address.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
