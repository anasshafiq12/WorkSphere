using Domain.Models;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
	public class DashboardStatsRepository:IDashboardStatsRepository
	{
		private readonly AppDbContext _context;

		public DashboardStatsRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task<DashboardStats> GetDashboardStatsAsync()
		{


			var employees = await _context.Employees.ToListAsync();
			var projects = await _context.Projects.ToListAsync();
			int totalProjects = projects.Count;
			int totalEmployees = employees.Count;
			int newEmployees = employees.Count(e => e.JoinDate.Month == DateTime.Now.Month && e.JoinDate.Year == DateTime.Now.Year);
			decimal totalSalary = employees.Sum(e => e.TotalSalaryTaken);
			decimal averageSalary = employees.Any() ? employees.Average(e => e.PerMonthSalary) : 0;

			return new DashboardStats
			{
				TotalProjects = totalProjects,
				TotalEmployees = totalEmployees,
				TotalSalary = totalSalary,
				AverageSalary = averageSalary
			};
		}

		public async Task<List<SalaryStat>> GetSalaryStatsAsync()
		{
			var employees = await _context.Employees.ToListAsync();

			var grouped = employees
				.GroupBy(e => new
				{
					Quarter = $"Q{((e.JoinDate.Month - 1) / 3) + 1} {e.JoinDate.Year}"
				})
				.Select(g => new SalaryStat
				{
					Quarter = g.Key.Quarter,
					Developer = g.Where(e => e.Role.ToLower().Contains("developer")).Sum(e => e.TotalSalaryTaken),
					Marketing = g.Where(e => e.Role.ToLower().Contains("marketing")).Sum(e => e.TotalSalaryTaken),
					Sales = g.Where(e => e.Role.ToLower().Contains("sales")).Sum(e => e.TotalSalaryTaken)
				})
				.OrderByDescending(s => s.Quarter)
				.ToList();

			return grouped;
		}

		public async Task<IncomeAnalysis> GetIncomeAnalysisAsync()
		{
			var employees = await _context.Employees.ToListAsync();

			decimal total = employees.Sum(e => e.TotalSalaryTaken);

			if (total == 0)
			{
				return new IncomeAnalysis();
			}

			decimal design = employees.Where(e => e.Role.ToLower().Contains("developer")).Sum(e => e.TotalSalaryTaken);
			decimal dev = employees.Where(e => e.Role.ToLower().Contains("marketing") || e.Role.ToLower().Contains("dev")).Sum(e => e.TotalSalaryTaken);
			decimal seo = employees.Where(e => e.Role.ToLower().Contains("sales")).Sum(e => e.TotalSalaryTaken);

			return new IncomeAnalysis
			{
				DesignPercentage = Math.Round((design / total) * 100, 2),
				DevPercentage = Math.Round((dev / total) * 100, 2),
				SEOPercentage = Math.Round((seo / total) * 100, 2)
			};
		}

	}
}
