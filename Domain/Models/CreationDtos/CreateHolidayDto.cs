using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.CreationDtos
{
	public class CreateHolidayDto
	{
		[Required(ErrorMessage = "Date is required")]
		public DateTime Date { get; set; }

		[Required(ErrorMessage = "Holiday name is required")]
		public string Name { get; set; } = string.Empty;
	}
}
