namespace FinesseApp.Common.Models;

public class Bid : BaseEntity
{
	public string VendorId { get; set; } = default!;
	public Vendor Vendor { get; set; } = default!;
	public int ProjectId { get; set; }
	public Project Project { get; set; } = default!;
	public decimal Amount { get; set; }
	public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
}
