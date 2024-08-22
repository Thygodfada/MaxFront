namespace FinesseApp.Common.Models;

public class Project : BaseEntity
{
	public string Title { get; set; }
	public string Description { get; set; }
	public DateTime Deadline { get; set; }

	public List<Bid> Bids { get; set; }
}
