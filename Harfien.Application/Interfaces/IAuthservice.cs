using Harfien.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harfien.Application.Interfaces
{
    public interface IAuthservice
    {
        Task<bool> ConfirmPasswordAsync(string userId, string password);
        Task<bool> VerifyResetCodeAsync(string userId, string resetCode);

    }
}
