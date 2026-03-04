using Harfien.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harfien.Application.Interfaces
{
    public  interface IClientService
    {
        Task<List<ClientDto>> GetAllAsync();
        Task<ClientDto> GetByIdAsync(int id);
        Task UpdateAsync(int id, string fullName);
        Task DeleteAsync(int id);
        Task<List<ClientDto>> SearchAsync(string keyword);
    }
}
