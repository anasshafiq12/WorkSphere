using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
	public interface IDashboardService
	{
		Task<DashboardStats> GetDashboardStatsAsync();
		Task<List<SalaryStat>> GetSalaryStatsAsync();
		Task<IncomeAnalysis> GetIncomeAnalysisAsync();
	}
}
