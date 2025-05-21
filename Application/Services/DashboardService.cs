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
	public class DashboardService :IDashboardService
	{
		private readonly IDashboardStatsRepository _dashboardStatsRepository;
		public DashboardService(IDashboardStatsRepository dashboardStatsRepository) {
			_dashboardStatsRepository = dashboardStatsRepository;
		}
		public async Task<DashboardStats> GetDashboardStatsAsync()
		{
			return await _dashboardStatsRepository.GetDashboardStatsAsync();
		}
		public async Task<List<SalaryStat>> GetSalaryStatsAsync()
		{
			return await _dashboardStatsRepository.GetSalaryStatsAsync();
		}
		public async Task<IncomeAnalysis> GetIncomeAnalysisAsync()
		{
			return await _dashboardStatsRepository.GetIncomeAnalysisAsync();
		}
	}
}
