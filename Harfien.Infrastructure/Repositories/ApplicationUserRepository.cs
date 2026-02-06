using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Harfien.Application.Dtos;
using Harfien.Domain.Entities;
using Harfien.Domain.Shared.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Harfien.Infrastructure.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;


        public ApplicationUserRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public Task<string> AddRoleAsync(AddRoleModel model)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> GetTokenAsync(TokenRequestModel model)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> RefreshTokenAsync(string token)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> RegisterAsync(RegisterModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RevokTokenAsync(string token)
        {
            throw new NotImplementedException();
        }
    }

}
