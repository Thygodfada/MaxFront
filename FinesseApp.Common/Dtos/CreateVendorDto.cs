namespace FinesseApp.Common.Dtos;

public class CreateVendorDto
{
	public string Name { get; set; }
	public string Email { get; set; } = default!;
	public string Password { get; set; } = default!;
}
