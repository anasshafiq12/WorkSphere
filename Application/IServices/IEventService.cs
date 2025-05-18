using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
	public interface IEventService
	{
		Task<IEnumerable<Event>> GetAllEventsAsync();
		Task<Event> GetEventByIdAsync(int id);
		Task AddEventAsync(Event eventDto);
		Task UpdateEventAsync(int id, Event eventDto);
		Task DeleteEventAsync(int id);
	}
}
