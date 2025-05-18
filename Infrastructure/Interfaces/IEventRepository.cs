using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
	public interface IEventRepository
	{
		Task<IEnumerable<Event>> GetAllAsync();
		Task<Event?> GetByIdAsync(int id);
		Task AddAsync(Event evnt);
		Task UpdateAsync(Event evnt);
		Task DeleteAsync(int id);
	}
}
