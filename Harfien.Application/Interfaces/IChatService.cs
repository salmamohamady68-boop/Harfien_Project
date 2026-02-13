using Harfien.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harfien.Application.Interfaces
{
  
    public interface IChatService
    {
        Task<int> CreateChatAsync(AddChatDto dto, string userId);
        Task<object> GetByOrderIdAsync(int orderId);
    }
}
