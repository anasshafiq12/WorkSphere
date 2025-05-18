using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
	public interface IHolidayRepository
	{
		Task<IEnumerable<Holiday>> GetAllAsync();
		Task<Holiday?> GetByIdAsync(int id);
		Task AddAsync(Holiday holiday);
		Task UpdateAsync(Holiday holiday);
		Task DeleteAsync(int id);
	}
}
