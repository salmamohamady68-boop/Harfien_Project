using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harfien.Domain.Entities
{
	public interface IChatMessageRepository
    {
		
			Task<IEnumerable<ChatMessage>> GetAllAsync();
			Task<ChatMessage?> GetByIdAsync(int id);
			Task InsertAsync(ChatMessage message);
			void Update(ChatMessage message);
			Task DeleteAsync(int id);
		
	}
}
