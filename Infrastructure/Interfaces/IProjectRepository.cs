using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
	public interface IProjectRepository
	{
		Task<IEnumerable<Project>> GetAllAsync();
		Task<Project?> GetByIdAsync(int id);
		Task AddAsync(Project project);
		Task UpdateAsync(Project project);
		Task DeleteAsync(int id);
	}
}
