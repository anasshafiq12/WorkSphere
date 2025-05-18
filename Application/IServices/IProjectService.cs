using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
	public interface IProjectService
	{
		Task<IEnumerable<Project>> GetAllProjectsAsync();
		Task<Project> GetProjectByIdAsync(int id);
		Task AddProjectAsync(Project projectDto);
		Task UpdateProjectAsync(int id, Project projectDto);
		Task DeleteProjectAsync(int id);
	}

}
