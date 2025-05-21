using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{

	public class SalaryStat
	{
		public string Quarter { get; set; } = string.Empty;
		public decimal Developer { get; set; }
		public decimal Marketing { get; set; }
		public decimal Sales { get; set; }
	}
}
