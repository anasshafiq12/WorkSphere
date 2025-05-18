using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
	public interface IActivityRepository
	{
		Task<IEnumerable<Activit>> GetAllAsync();
		Task<Activit?> GetByIdAsync(int id);
		Task AddAsync(Activit activit);
		Task UpdateAsync(Activit activit);
		Task DeleteAsync(int id);
	}
}
