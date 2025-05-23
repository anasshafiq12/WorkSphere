using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
	public class ToDo
	{
		[Key]
		public int Id { get; set; }
		public string Content { get; set; }
		public bool isDone { get; set; } = false;
		public DateTime Date { get; set; } = System.DateTime.Now;
	}
}
