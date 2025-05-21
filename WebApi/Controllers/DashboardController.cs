using Application.IServices;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class DashboardController : ControllerBase
	{
		private readonly IDashboardService _dashboardService;

		public DashboardController(IDashboardService dashboardService)
		{
			_dashboardService = dashboardService;
		}

		[HttpGet("stats")]
		public async Task<ActionResult<DashboardStats>> GetDashboardStats()
		{
			var stats = await _dashboardService.GetDashboardStatsAsync();
			return Ok(stats);
		}

		[HttpGet("salaryStats")]
		public async Task<ActionResult<List<SalaryStat>>> GetSalaryStats()
		{
			var salaryStats = await _dashboardService.GetSalaryStatsAsync();
			return Ok(salaryStats);
		}

		[HttpGet("incomeAnalysis")]
		public async Task<ActionResult<IncomeAnalysis>> GetIncomeAnalysis()
		{
			var analysis = await _dashboardService.GetIncomeAnalysisAsync();
			return Ok(analysis);
		}
	}
}
