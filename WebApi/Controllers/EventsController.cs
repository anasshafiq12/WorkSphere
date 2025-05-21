
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Domain.Models.CreationDtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.IServices;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EventsController : ControllerBase
	{
		private readonly IEventService _eventService;
		public EventsController(IEventService eventService)
		{
			_eventService = eventService;
		}

		// Get all events
		[HttpGet("GetAllEvents")]
		public async Task<ActionResult<IEnumerable<Event>>> GetAllEvents()
		{
			var events = await _eventService.GetAllEventsAsync();
			return Ok(events);
		}

		// Get event by ID
		[HttpGet("GetEventById/{id}")]
		public async Task<ActionResult<Event>> GetEventById(int id)
		{
			var eventItem = await _eventService.GetEventByIdAsync(id);
			if (eventItem == null)
			{
				return NotFound();
			}
			return Ok(eventItem);
		}

		// Create a new event
		[HttpPost("AddEvent")]
		public async Task<ActionResult> AddEvent([FromBody] CreateEventDto eventDto)
		{
			var eventItem = new Event()
			{
				Title = eventDto.Title,
				Description = eventDto.Description,
				Date = eventDto.Date,
				IsAllDay = eventDto.IsAllDay,
				IsImportant = eventDto.IsImportant,
				Location = eventDto.Location
			};

			await _eventService.AddEventAsync(eventItem);
			return CreatedAtAction(nameof(GetEventById), new { id = eventItem.Id }, eventItem);
		}

		// Update an event
		[HttpPut("UpdateEvent/{id}")]
		public async Task<ActionResult> UpdateEvent(int id, [FromBody] UpdateEventDto eventDto)
		{
			var eventItem = new Event()
			{
				Id = id,
				Title = eventDto.Title,
				Description = eventDto.Description,
				Date = eventDto.Date,
				IsAllDay = eventDto.IsAllDay,
				IsImportant = eventDto.IsImportant,
				Location = eventDto.Location
			};

			await _eventService.UpdateEventAsync(id, eventItem);
			return NoContent();
		}

		// Delete an event
		[HttpDelete("DeleteEvent/{id}")]
		public async Task<ActionResult> DeleteEvent(int id)
		{
			await _eventService.DeleteEventAsync(id);
			return NoContent();
		}
	}
}

