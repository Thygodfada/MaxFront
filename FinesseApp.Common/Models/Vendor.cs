namespace FinesseApp.Common.Models;

public class Vendor 
{
	public string Id { get; set; } = string.Empty;
	public string Name { get; set; } = default!;
	public string Email { get; set; } = default!;
	public string Password { get; set; } = default!;
	public DateTime RegisteredAt { get; set; } = DateTime.Now;

	public List<Bid> Bids { get; set; } = new List<Bid>();
}
