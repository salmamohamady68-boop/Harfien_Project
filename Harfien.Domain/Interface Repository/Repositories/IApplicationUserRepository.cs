using Harfien.Application.Dtos;
using Harfien.Domain.Entities;


namespace Harfien.Domain.Shared.Repositories
{
    public interface IApplicationUserRepository
    {
        Task<ApplicationUser> RegisterAsync(RegisterModel model);
        Task<ApplicationUser> GetTokenAsync(TokenRequestModel model);
        Task<string> AddRoleAsync(AddRoleModel model);
        Task<ApplicationUser> RefreshTokenAsync(string token);
        Task<bool> RevokTokenAsync(string token);
    }

}
