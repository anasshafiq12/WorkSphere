using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.CreationDtos
{
	public class CreateProjectDto
	{
		public string Title { get; set; } = string.Empty;

		public string Description { get; set; } = string.Empty;

		public string ImageUrl { get; set; } = string.Empty;

		public int Progress { get; set; }

		public List<string> TeamAvatars { get; set; } = new();

		public List<string> ClientIds { get; set; } = new(); // Assuming you relate by ClientID
	}
}
