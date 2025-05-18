using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
	public class Activit
	{
		[Key]
		public int Id { get; set; }
		public string Title { get; set; } = "";
		public string Description { get; set; } = "";
		public DateTime TimeStamp { get; set; }
		public string TimeStampHumanized => TimeStamp.ToString("MMM d, yyyy h:mm tt");
		public string Status { get; set; } = "New"; // New, Recent
	}
}
