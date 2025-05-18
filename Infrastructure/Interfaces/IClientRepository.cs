using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
	public interface IClientRepository
	{
		Task<IEnumerable<ClientModel>> GetAllAsync();
		Task<ClientModel?> GetByIdAsync(int clientId);
		Task AddAsync(ClientModel client);
		Task UpdateAsync(ClientModel client);
		Task DeleteAsync(int clientId);

	}
}
