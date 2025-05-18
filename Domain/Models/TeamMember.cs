

using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
	public class TeamMember
	{
		[Key]
		public int Id { get; set; }
		public Employee Employee {  get; set; }
		public Project Project { get; set; }
		public string Name { get; set; } = "";
		public bool isSelected { get; set; }

		public string AvatarUrl { get; set; } = "https://i.pravatar.cc/30";
	}
}
