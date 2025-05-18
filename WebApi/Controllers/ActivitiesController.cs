using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.IServices;
using Domain.Models.CreationDtos; // Import this if you have any DTOs like `CreateActivityDto`


namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]

	public class ActivitiesController : ControllerBase
	{
		private readonly IActivityService _activityService;
		private readonly ITeamMemberService _teamMemberService;
		public ActivitiesController(IActivityService activityService, ITeamMemberService teamMemberService)
		{
			_activityService = activityService;
			_teamMemberService = teamMemberService;
		}

		// Get all activities
		[HttpGet("GetAllActivities")]
		public async Task<ActionResult<IEnumerable<Activit>>> GetAllActivities()
		{
			var activities = await _activityService.GetAllActivitiesAsync();
			return Ok(activities);
		}

		// Get an activity by ID
		[HttpGet("GetActivityById{id}")]
		public async Task<ActionResult<Activit>> GetActivityById(int id)
		{
			var activity = await _activityService.GetActivityByIdAsync(id);
			if (activity == null)
			{
				return NotFound();
			}
			return Ok(activity);
		}

		// Create a new activity
		[HttpPost("CreateActivity")]
		public async Task<ActionResult> CreateActivity([FromBody] CreateActivityDto activityDto)
		{


			
			var activity = new Activit()
			{
				Title = activityDto.Title,
				Description = activityDto.Description,
				Status = activityDto.Status,
				TimeStamp = activityDto.TimeStamp
			};

			await _activityService.CreateActivityAsync(activity);
			return CreatedAtAction(nameof(GetActivityById), new { id = activity.Id }, activity);
		}

		// Update an existing activity
		[HttpPut("UpdateActivity{id}")]
		public async Task<ActionResult> UpdateActivity(int id, [FromBody] CreateActivityDto activityDto)
		{
			var activity = new Activit()
			{
				Id = id,
				Title = activityDto.Title,
				Description = activityDto.Description,
				// Add other properties as needed
			};

			await _activityService.UpdateActivityAsync(activity);
			return NoContent();
		}

		// Delete an activity
		[HttpDelete("DeleteActivity{id}")]
		public async Task<ActionResult> DeleteActivity(int id)
		{
			await _activityService.DeleteActivityAsync(id);
			return NoContent();
		}
	}
}