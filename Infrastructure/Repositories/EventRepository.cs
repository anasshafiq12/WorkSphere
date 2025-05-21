using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories
{
	public class EventRepository : IEventRepository
	{
		private readonly AppDbContext _context;

		public EventRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Event>> GetAllAsync()
		{
			return await _context.Events.ToListAsync();
		}

		public async Task<Event?> GetByIdAsync(int id)
		{
			return await _context.Events.FindAsync(id);
		}

		public async Task AddAsync(Event evnt)
		{
			

			await _context.Events.AddAsync(evnt);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(Event evnt)
		{
			var trackedEntity = _context.ChangeTracker.Entries<Event>()
										.FirstOrDefault(e => e.Entity.Id == evnt.Id);

			if (trackedEntity != null)
			{
				trackedEntity.State = EntityState.Detached;
			}

			_context.Events.Update(evnt);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var evnt = await _context.Events.FindAsync(id);
			if (evnt != null)
			{
				_context.Events.Remove(evnt);
				await _context.SaveChangesAsync();
			}
		}
	}
}
