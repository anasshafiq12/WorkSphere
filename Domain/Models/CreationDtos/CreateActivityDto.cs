using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.CreationDtos
{
	public class CreateActivityDto
	{
		[Required(ErrorMessage = "Title is required")]
		public string Title { get; set; } = string.Empty;

		[Required(ErrorMessage = "Description is required")]
		public string Description { get; set; } = string.Empty;

		[Required(ErrorMessage = "Timestamp is required")]
		public DateTime TimeStamp { get; set; } = DateTime.Now;

		[Required(ErrorMessage = "Status is required")]
		public string Status { get; set; } = "New";

	}

}
