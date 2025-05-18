using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Models.CreationDtos;
using Application.IServices;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HolidaysController : ControllerBase
	{
		private readonly IHolidayService _holidayService;

		public HolidaysController(IHolidayService holidayService)
		{
			_holidayService = holidayService;
		}

		[HttpGet("GetAllHolidays")]
		public async Task<ActionResult<IEnumerable<Holiday>>> GetAllHolidays()
		{
			var holidays = await _holidayService.GetAllHolidaysAsync();
			return Ok(holidays);
		}

		[HttpGet("GetHolidayById/{id}")]
		public async Task<ActionResult<Holiday>> GetHolidayById(int id)
		{
			var holiday = await _holidayService.GetHolidayByIdAsync(id);
			if (holiday == null)
			{
				return NotFound();
			}
			return Ok(holiday);
		}

		[HttpPost("AddHoliday")]
		public async Task<ActionResult> AddHoliday([FromBody] CreateHolidayDto holidayDto)
		{
			var holiday = new Holiday
			{
				Date = holidayDto.Date,
				Name = holidayDto.Name
			};

			await _holidayService.AddHolidayAsync(holiday);
			return CreatedAtAction(nameof(GetHolidayById), new { id = holiday.Id }, holiday);
		}

		[HttpPut("UpdateHoliday/{id}")]
		public async Task<ActionResult> UpdateHoliday(int id, [FromBody] CreateHolidayDto holidayDto)
		{
			var holiday = new Holiday
			{
				Id = id,
				Date = holidayDto.Date,
				Name = holidayDto.Name
			};

			await _holidayService.UpdateHolidayAsync(id, holiday);
			return NoContent();
		}

		[HttpDelete("DeleteHoliday/{id}")]
		public async Task<ActionResult> DeleteHoliday(int id)
		{
			await _holidayService.DeleteHolidayAsync(id);
			return NoContent();
		}
	}
}
