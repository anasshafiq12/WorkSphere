using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories
{
	public class HolidayRepository:IHolidayRepository
	{
		private readonly AppDbContext _context;

		public HolidayRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Holiday>> GetAllAsync()
		{
			return await _context.Holidays.ToListAsync();
		}

		public async Task<Holiday?> GetByIdAsync(int id)
		{
			return await _context.Holidays.FindAsync(id);
		}

		public async Task AddAsync(Holiday holiday)
		{
			await _context.Holidays.AddAsync(holiday);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(Holiday holiday)
		{
			_context.Holidays.Update(holiday);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var holiday = await _context.Holidays.FindAsync(id);
			if (holiday != null)
			{
				_context.Holidays.Remove(holiday);
				await _context.SaveChangesAsync();
			}
		}
	}
}
