using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
	public class ClientModel
	{
		[Key]
		public int ClientID { get; set; } 

		public string FirstName { get; set; } = string.Empty;

		public string LastName { get; set; } = string.Empty;


		public string Email { get; set; } = string.Empty;

		public string Username { get; set; } = string.Empty;
		public string ProfilePictureUrl { get; set; } = string.Empty;


		public string Password { get; set; } = string.Empty;


		public string ConfirmPassword { get; set; } = string.Empty;


		public string MobileNo { get; set; } = string.Empty;



		public string Address { get; set; } = string.Empty;

		public bool ProjectsRead { get; set; }
		public bool ProjectsWrite { get; set; }
		public bool ProjectsDelete { get; set; }

		public bool TasksRead { get; set; }
		public bool TasksWrite { get; set; }
		public bool TasksDelete { get; set; }
	}

}
