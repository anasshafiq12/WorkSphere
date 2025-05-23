using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
	public interface IToDoRepository
	{
		Task<IEnumerable<ToDo>> GetAllAsync();
		Task<ToDo> GetByIdAsync(int id);
		Task AddAsync(ToDo todo);
		Task UpdateAsync(ToDo todo);
		Task DeleteAsync(int id);
	}
}
