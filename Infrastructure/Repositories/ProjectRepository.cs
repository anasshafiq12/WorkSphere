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
	public class ProjectRepository:IProjectRepository
	{
		private readonly AppDbContext _context;

		public ProjectRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Project>> GetAllAsync()
		{
			return await _context.Projects
				.Include(p => p.Clients)
				.ToListAsync();
		}

		public async Task<Project?> GetByIdAsync(int id)
		{
			return await _context.Projects
				.Include(p => p.Clients)
				.FirstOrDefaultAsync(p => p.Id == id);
		}

		public async Task AddAsync(Project project)
		{
			
			await _context.Projects.AddAsync(project);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(Project project)
		{
			var existing = await _context.Projects.FindAsync(project.Id);
			if (existing == null) return;

			// Manually update properties
			existing.Title = project.Title;
			existing.Description = project.Description;
			existing.ImageUrl = project.ImageUrl;
			existing.Progress = project.Progress;

			// Update TeamAvatars (replacing the list)
			existing.TeamAvatars = project.TeamAvatars;

			// Handle Clients if needed
			existing.Clients = project.Clients;

			await _context.SaveChangesAsync();
		}


		public async Task DeleteAsync(int id)
		{
			var project = await _context.Projects.FindAsync(id);
			if (project != null)
			{
				_context.Projects.Remove(project);
				await _context.SaveChangesAsync();
			}
		}
	}
}
