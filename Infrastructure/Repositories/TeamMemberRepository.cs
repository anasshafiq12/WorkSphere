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
	public class TeamMemberRepository:ITeamMemberRepository
	{
		private readonly AppDbContext _context;

		public TeamMemberRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<TeamMember>> GetAllAsync()
		{
			return await _context.TeamMembers
				.Include(tm => tm.Employee)
				.Include(tm => tm.Project)
				.ToListAsync();
		}

		public async Task<TeamMember?> GetByIdAsync(int id)
		{
			return await _context.TeamMembers
				.Include(tm => tm.Employee)
				.Include(tm => tm.Project)
				.FirstOrDefaultAsync(tm => tm.Id == id);
		}

		public async Task AddAsync(TeamMember teamMember)
		{
			await _context.TeamMembers.AddAsync(teamMember);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(TeamMember teamMember)
		{
			_context.TeamMembers.Update(teamMember);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var teamMember = await _context.TeamMembers.FindAsync(id);
			if (teamMember != null)
			{
				_context.TeamMembers.Remove(teamMember);
				await _context.SaveChangesAsync();
			}
		}
	}
}
