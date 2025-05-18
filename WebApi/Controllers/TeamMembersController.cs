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
	public class TeamMembersController : ControllerBase
	{
		private readonly ITeamMemberService _teamMemberService;

		public TeamMembersController(ITeamMemberService teamMemberService)
		{
			_teamMemberService = teamMemberService;
		}

		[HttpGet("GetAllTeamMembers")]
		public async Task<ActionResult<IEnumerable<TeamMember>>> GetAllTeamMembers()
		{
			var members = await _teamMemberService.GetAllTeamMembersAsync();
			return Ok(members);
		}

		[HttpGet("GetTeamMemberById/{id}")]
		public async Task<ActionResult<TeamMember>> GetTeamMemberById(int id)
		{
			var member = await _teamMemberService.GetTeamMemberByIdAsync(id);
			if (member == null)
				return NotFound();

			return Ok(member);
		}

		[HttpPost("AddTeamMember")]
		public async Task<ActionResult> AddTeamMember([FromBody] CreateTeamMemberDto dto)
		{
			var member = new TeamMember
			{
				Name = dto.Name,
				AvatarUrl = dto.AvatarUrl,
				Employee = new Employee { Id = dto.EmployeeId },
				Project = new Project { Id = dto.ProjectId }
			};

			await _teamMemberService.AddTeamMemberAsync(member);
			return CreatedAtAction(nameof(GetTeamMemberById), new { id = member.Id }, member);
		}

		[HttpPut("UpdateTeamMember/{id}")]
		public async Task<ActionResult> UpdateTeamMember(int id, [FromBody] CreateTeamMemberDto dto)
		{
			var member = new TeamMember
			{
				Id = id,
				Name = dto.Name,
				AvatarUrl = dto.AvatarUrl,
				Employee = new Employee { Id = dto.EmployeeId },
				Project = new Project { Id = dto.ProjectId }
			};

			await _teamMemberService.UpdateTeamMemberAsync(id, member);
			return NoContent();
		}

		[HttpDelete("DeleteTeamMember/{id}")]
		public async Task<ActionResult> DeleteTeamMember(int id)
		{
			await _teamMemberService.DeleteTeamMemberAsync(id);
			return NoContent();
		}
	}
}
