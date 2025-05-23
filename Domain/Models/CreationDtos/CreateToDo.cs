using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.CreationDtos
{
	public class CreateToDo
	{
		public string Content { get; set; }
		public bool isDone { get; set; } = false;
	}
}
