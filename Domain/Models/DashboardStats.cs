using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
	public class DashboardStats
	{
		public int TotalProjects { get; set; }
		public int TotalEmployees { get; set; }
		public decimal TotalSalary { get; set; }
		public decimal AverageSalary { get; set; }
	}
}
