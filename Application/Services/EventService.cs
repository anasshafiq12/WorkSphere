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
	public class EventService : IEventService
	{
		private readonly IEventRepository _eventRepository;

		public EventService(IEventRepository eventRepository)
		{
			_eventRepository = eventRepository;
		}

		public async Task<IEnumerable<Event>> GetAllEventsAsync() => await _eventRepository.GetAllAsync();
		public async Task<Event> GetEventByIdAsync(int id) => await _eventRepository.GetByIdAsync(id);
		public async Task AddEventAsync(Event eventDto) => await _eventRepository.AddAsync(eventDto);
		public async Task UpdateEventAsync(int id, Event eventDto)
		{
			var evnt = await _eventRepository.GetByIdAsync(id);
			if (evnt != null)
			{
				await _eventRepository.UpdateAsync(eventDto);
			}
		}
		public async Task DeleteEventAsync(int id) => await _eventRepository.DeleteAsync(id);
	}

}
