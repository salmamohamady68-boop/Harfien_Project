using Harfien.Application.Dtos.Auth;
using Harfien.Application.Dtos.AuthDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harfien.Domain.Interface_Repository.Services
{
    public interface IAuthService
    {
        Task<string> RegisterClientAsync(RegisterClientDto dto);
        Task RegisterCraftsmanAsync(RegisterCraftsmanDto dto);
        Task<string> LoginAsync(loginDto dto);
        Task<string> ApproveCraftsmanAsync(int craftsmanId);
    }
}
