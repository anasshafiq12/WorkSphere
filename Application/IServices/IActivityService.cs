using Domain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
	public interface IActivityService
	{
		Task<IEnumerable<Activit>> GetAllActivitiesAsync();
		Task<Activit?> GetActivityByIdAsync(int id);
		Task CreateActivityAsync(Activit activity);
		Task UpdateActivityAsync(Activit activity);
		Task DeleteActivityAsync(int id);
	}

}
