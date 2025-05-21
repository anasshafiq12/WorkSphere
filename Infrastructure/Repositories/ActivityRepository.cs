using Domain.Models;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
	public class ActivityRepository: IActivityRepository
	{
		private readonly AppDbContext _context;

		public ActivityRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Activit>> GetAllAsync()
		{
			return await _context.Activities
				.ToListAsync();
		}

		public async Task<Activit?> GetByIdAsync(int id)
		{
			return await _context.Activities
				.FirstOrDefaultAsync(a => a.Id == id);
		}

		public async Task AddAsync(Activit activit)
		{
			

			await _context.Activities.AddAsync(activit);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(Activit activit)
		{
			var existing = await _context.Activities.FindAsync(activit.Id);
			if (existing == null) return;

			// Manually update properties
			existing.Title = activit.Title;
			existing.Description = activit.Description;
			existing.Status = activit.Status;
			existing.TimeStamp = activit.TimeStamp;
			await _context.SaveChangesAsync();
		}


		public async Task DeleteAsync(int id)
		{
			var activit = await _context.Activities.FindAsync(id);
			if (activit != null)
			{
				_context.Activities.Remove(activit);
				await _context.SaveChangesAsync();
			}
		}
	}
}
