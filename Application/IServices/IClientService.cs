using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
	public interface IClientService
	{
		Task<IEnumerable<ClientModel>> GetAllClientsAsync();
		Task<ClientModel> GetClientByIdAsync(int clientId);
		Task AddClientAsync(ClientModel clientDto);
		Task UpdateClientAsync(int clientId, ClientModel clientDto);
		Task DeleteClientAsync(int clientId);
	}
}
