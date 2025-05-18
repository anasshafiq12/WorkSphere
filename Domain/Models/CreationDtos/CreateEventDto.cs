using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.CreationDtos
{
	public class CreateEventDto
	{
		[Required(ErrorMessage = "Title is required")]
		public string Title { get; set; } = string.Empty;

		[Required(ErrorMessage = "Description is required")]
		public string Description { get; set; } = string.Empty;

		[Required(ErrorMessage = "Date is required")]
		public DateTime Date { get; set; }

		public bool IsAllDay { get; set; }

		public bool IsImportant { get; set; }

		[Required(ErrorMessage = "Location is required")]
		public string Location { get; set; } = string.Empty;
	}
}
