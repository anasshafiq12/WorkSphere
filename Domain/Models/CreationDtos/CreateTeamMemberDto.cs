using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.CreationDtos
{
	public class CreateTeamMemberDto
	{
		[Required(ErrorMessage = "EmployeeId is required")]
		public int EmployeeId { get; set; }

		[Required(ErrorMessage = "ProjectId is required")]
		public int ProjectId { get; set; }

		[Required(ErrorMessage = "Name is required")]
		public string Name { get; set; } = string.Empty;
		public bool isSelected { get; set; }

		public string AvatarUrl { get; set; } = "https://i.pravatar.cc/30";
	}
}
