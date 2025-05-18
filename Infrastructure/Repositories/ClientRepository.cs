using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories
{
	public class ClientRepository: IClientRepository
	{
		private readonly AppDbContext _context;

		public ClientRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<ClientModel>> GetAllAsync()
		{
			
			return await _context.Clients.ToListAsync();
		}

		public async Task<ClientModel?> GetByIdAsync(int clientId)
		{
			return await _context.Clients.FindAsync(clientId);
		}

		public async Task AddAsync(ClientModel client)
		{
			

			await _context.Clients.AddAsync(client);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(ClientModel client)
		{
			_context.Clients.Update(client);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int clientId)
		{
			var client = await _context.Clients.FindAsync(clientId);
			if (client != null)
			{
				_context.Clients.Remove(client);
				await _context.SaveChangesAsync();
			}
		}
	}
}
