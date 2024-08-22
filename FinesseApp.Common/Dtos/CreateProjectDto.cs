namespace FinesseApp.Common.Dtos;

public class CreateProjectDto
{
	public string Title { get; set; } = default!;
	public string Description { get; set; } = default!;
	public DateTime Deadline { get; set; } 
}
