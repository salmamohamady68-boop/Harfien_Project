using Harfien.Application.DTO;
using Harfien.Domain.Entities;
using Harfien.Domain.Interface_Repository.Repositories;
using Harfien.Domain.Interface_Repository.Services;
using Harfien.Domain.Shared.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ICraftsmanRepository _craftsmanRepo;
    private readonly IJwtTokenService _jwtService;
    private readonly IConfiguration _configuration;
    private readonly IEmailService _emailSender;
    private readonly IMemoryCache _cache;



    public AuthService(
        UserManager<ApplicationUser> userManager,
        ICraftsmanRepository craftsmanRepo,
        IJwtTokenService jwtService,
        IConfiguration configuration,
        IEmailService emailSender,
        IMemoryCache cache)
    {
        _userManager = userManager;
        _craftsmanRepo = craftsmanRepo;
        _jwtService = jwtService;
        _configuration = configuration;
        _emailSender = emailSender;
        _cache = cache;
    }

    public async Task<string> RegisterClientAsync(RegisterClientDto dto)
    {
        var user = new ApplicationUser
        {
            UserName = dto.Email,
            Email = dto.Email,
            FullName = dto.FullName
        };

        var result = await _userManager.CreateAsync(user, dto.Password);
        if (!result.Succeeded)
            throw new Exception("Register failed");

        await _userManager.AddToRoleAsync(user, "Client");
        return await _jwtService.GenerateTokenAsync(user);
    }

    public async Task RegisterCraftsmanAsync(RegisterCraftsmanDto dto)
    {
        var user = new ApplicationUser
        {
            UserName = dto.PhoneNumber,
            PhoneNumber = dto.PhoneNumber,
            FullName = dto.FullName,
            AreaId = dto.CityId
        };

        var result = await _userManager.CreateAsync(user, dto.Password);
        if (!result.Succeeded)
            throw new Exception("Register failed");

        await _userManager.AddToRoleAsync(user, "Craftsman");

        await _craftsmanRepo.AddAsync(new Craftsman
        {
            UserId = user.Id,
            YearsOfExperience = dto.YearsOfExperience,
            IsApproved = false
        });
    }

    public async Task<string?> LoginAsync(loginDto dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.Identifier)
            ?? await _userManager.Users
                .FirstOrDefaultAsync(u => u.PhoneNumber == dto.Identifier);

        if (user == null || !await _userManager.CheckPasswordAsync(user, dto.Password))
        {
            Console.WriteLine("Login failed: user not found or wrong password");
            return null;
        }

        var roles = await _userManager.GetRolesAsync(user);
        if (roles.Contains("Craftsman"))
        {
            var craftsman = await _craftsmanRepo.GetByUserIdAsync(user.Id);
            if (craftsman != null && !craftsman.IsApproved)
            {
                Console.WriteLine("Login failed: Craftsman not approved yet");
                return null;
            }
        }

        // لو كل حاجة تمام تولد التوكن
        return await _jwtService.GenerateTokenAsync(user);
    }

    public async Task<string> ApproveCraftsmanAsync(int craftsmanId)
    {
        var craftsman = await _craftsmanRepo.GetByIdAsync(craftsmanId);
        if (craftsman == null)
            throw new Exception("Not found");

        craftsman.IsApproved = true;
        await _craftsmanRepo.UpdateAsync(craftsman);

        return await _jwtService.GenerateTokenAsync(craftsman.User);
    }


    public async Task<(bool Success, string Message)> ForgetPasswordAsync(ForgetPassword forgetPassword)
    {
        var user = await _userManager.FindByEmailAsync(forgetPassword.Email);

        if (user == null)
            return (false, "This email is not registered.");

        var code = Random.Shared.Next(10000, 100000).ToString();

        user.ResetCode = BCrypt.Net.BCrypt.HashPassword(code);
        user.ResetCodeExpiry = DateTime.UtcNow.AddMinutes(10);

        await _userManager.UpdateAsync(user);

        await _emailSender.SendAsync(
            user.Email,
            "Password Reset Code",
            $"Your password reset code is: {code}\nThis code expires in 10 minutes."
        );

        return (true, "Your reset code has been sent to your email.");
    }



    public async Task<string?> VerifyResetCode(VerifyResetCode dto)
    {
        var user = _userManager.Users
            .AsEnumerable()
            .FirstOrDefault(u =>
                u.ResetCode != null &&
                BCrypt.Net.BCrypt.Verify(dto.Code, u.ResetCode));

        if (user == null)
            return null;

        if (user.ResetCodeExpiry < DateTime.UtcNow)
            return null;

        // store userId temporarily (10 minutes)
        _cache.Set("PasswordResetUser", user.Id, TimeSpan.FromMinutes(10));

        return "Code verified";
    }

    public async Task<string?> ResetPassword(ResetPassword dto)
    {
        // 1️⃣ Get userId from cache
        if (!_cache.TryGetValue("PasswordResetUser", out string userId))
            return "Verification expired";

        // 2️⃣ Find user
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            return "User not found";

        // 3️⃣ Generate reset token
        var token = await _userManager.GeneratePasswordResetTokenAsync(user);

        // 4️⃣ Reset password
        var result = await _userManager.ResetPasswordAsync(user, token, dto.NewPassword);

        if (!result.Succeeded)
            return string.Join(", ", result.Errors.Select(e => e.Description));

        // 5️⃣ Cleanup
        _cache.Remove("PasswordResetUser");

        user.ResetCode = null;
        user.ResetCodeExpiry = null;
        await _userManager.UpdateAsync(user);

        return "Password reset successfully";
    }


    public async Task<bool> ConfirmPasswordAsync(string userId, string password)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            return false;

        return await _userManager.CheckPasswordAsync(user, password);
    }

    public async Task<bool> VerifyResetCodeAsync(string userId, string resetCode)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            return false;

        return await _userManager.VerifyUserTokenAsync(
            user,
            _userManager.Options.Tokens.PasswordResetTokenProvider,
            "ResetPassword",
            resetCode
        );
    }




}

