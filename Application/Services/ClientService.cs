using Application.IServices;
using Domain.Models;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
	public class ClientService:IClientService
	{
		private readonly IClientRepository _clientRepository;

		public ClientService(IClientRepository clientRepository)
		{
			_clientRepository = clientRepository;
		}

		public async Task<IEnumerable<ClientModel>> GetAllClientsAsync()
		{
			return await _clientRepository.GetAllAsync();
		}

		public async Task<ClientModel> GetClientByIdAsync(int clientId)
		{
			return await _clientRepository.GetByIdAsync(clientId);
		}

		public async Task AddClientAsync(ClientModel clientDto)
		{
			await _clientRepository.AddAsync(clientDto);
		}

		public async Task UpdateClientAsync(int clientId, ClientModel clientDto)
		{
			var client = await _clientRepository.GetByIdAsync(clientId);
			if (client != null)
			{
				await _clientRepository.UpdateAsync(clientDto);
			}
		}

		public async Task DeleteClientAsync(int clientId)
		{
			await _clientRepository.DeleteAsync(clientId);
		}
	}
}
