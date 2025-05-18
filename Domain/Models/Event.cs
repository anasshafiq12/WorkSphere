using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
	public class Event
	{
		[Key]
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public DateTime Date { get; set; }
		public bool IsAllDay { get; set; }
		public bool IsImportant { get; set; }
		public string Location { get; set; } = string.Empty;
	}
}
