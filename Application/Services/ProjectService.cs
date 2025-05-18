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
	public class ProjectService : IProjectService
	{
		private readonly IProjectRepository _projectRepository;

		public ProjectService(IProjectRepository projectRepository)
		{
			_projectRepository = projectRepository;
		}

		public async Task<IEnumerable<Project>> GetAllProjectsAsync() => await _projectRepository.GetAllAsync();
		public async Task<Project> GetProjectByIdAsync(int id) => await _projectRepository.GetByIdAsync(id);
		public async Task AddProjectAsync(Project projectDto) => await _projectRepository.AddAsync(projectDto);
		public async Task UpdateProjectAsync(int id, Project projectDto)
		{
			var project = await _projectRepository.GetByIdAsync(id);
			if (project != null)
			{
				await _projectRepository.UpdateAsync(projectDto);
			}
		}
		public async Task DeleteProjectAsync(int id) => await _projectRepository.DeleteAsync(id);
	}

}
