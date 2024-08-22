using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinesseApp.Common.Dtos
{
	public class ProjectDto
	{
		public int Id { get; set; }
		public string Title { get; set; } = default!;
		public string Description { get; set; } = default!;
		public DateTime Deadline { get; set; } 
	}
}
