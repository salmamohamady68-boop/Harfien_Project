using Harfien.Application.Dtos.Auth;
using Harfien.Application.Dtos.AuthDtos;
using Harfien.Domain.Entities;
using Harfien.Domain.Interface_Repository.Services;
using Harfien.Domain.Shared.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ICraftsmanRepository _craftsmanRepo;
    private readonly IJwtTokenService _jwtService;

    public AuthService(
        UserManager<ApplicationUser> userManager,
        ICraftsmanRepository craftsmanRepo,
        IJwtTokenService jwtService)
    {
        _userManager = userManager;
        _craftsmanRepo = craftsmanRepo;
        _jwtService = jwtService;
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
}
