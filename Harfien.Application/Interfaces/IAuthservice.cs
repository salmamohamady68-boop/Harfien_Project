using Harfien.Application.DTO;

namespace Harfien.Application.Interfaces
{
    public interface IAuthService
    {
        Task<string> RegisterClientAsync(RegisterClientDto dto);
        Task RegisterCraftsmanAsync(RegisterCraftsmanDto dto);
        Task<string> LoginAsync(loginDto dto);
        Task<string> ApproveCraftsmanAsync(int craftsmanId);
        Task<(bool Success, string Message)> ForgetPasswordAsync(ForgetPassword forgetPassword);
        Task<string?> VerifyResetCode(VerifyResetCode dto);
        Task<string?> ResetPassword(ResetPassword dto);
        Task<bool> ConfirmPasswordAsync(string userId, string password);
        Task<bool> VerifyResetCodeAsync(string userId, string resetCode);
    }
}
