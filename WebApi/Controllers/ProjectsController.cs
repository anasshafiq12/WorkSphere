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
	public class ProjectsController : ControllerBase
	{
		private readonly IProjectService _projectService;

		public ProjectsController(IProjectService projectService)
		{
			_projectService = projectService;
		}

		[HttpGet("GetAllProjects")]
		public async Task<ActionResult<IEnumerable<Project>>> GetAllProjects()
		{
			var projects = await _projectService.GetAllProjectsAsync();
			return Ok(projects);
		}

		[HttpGet("GetProjectById/{id}")]
		public async Task<ActionResult<Project>> GetProjectById(int id)
		{
			var project = await _projectService.GetProjectByIdAsync(id);
			if (project == null)
			{
				return NotFound();
			}
			return Ok(project);
		}

		[HttpPost("AddProject")]
		public async Task<ActionResult> AddProject([FromBody] CreateProjectDto dto)
		{
			var project = new Project
			{
				Title = dto.Title,
				Description = dto.Description,
				ImageUrl = dto.ImageUrl,
				Progress = dto.Progress,
				TeamAvatars = dto.TeamAvatars,
				// Clients should be resolved by service from dto.ClientIds
			};

			await _projectService.AddProjectAsync(project);
			return CreatedAtAction(nameof(GetProjectById), new { id = project.Id }, project);
		}

		[HttpPut("UpdateProject/{id}")]
		public async Task<ActionResult> UpdateProject(int id, [FromBody] CreateProjectDto dto)
		{
			var project = new Project
			{
				Id = id,
				Title = dto.Title,
				Description = dto.Description,
				ImageUrl = dto.ImageUrl,
				Progress = dto.Progress,
				TeamAvatars = dto.TeamAvatars,
				// Clients should be resolved by service from dto.ClientIds
			};

			await _projectService.UpdateProjectAsync(id, project);
			return NoContent();
		}

		[HttpDelete("DeleteProject/{id}")]
		public async Task<ActionResult> DeleteProject(int id)
		{
			await _projectService.DeleteProjectAsync(id);
			return NoContent();
		}
	}
}
