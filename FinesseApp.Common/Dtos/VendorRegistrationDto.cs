namespace FinesseApp.Common.Dtos;

public class VendorRegistrationDto
{
	public string Name { get; set; } = default!;
	public string Email { get; set; } = default!;
	public string Password { get; set; } = default!;
	public DateTime RegisteredAt { get; set; } = DateTime.Now;
}
