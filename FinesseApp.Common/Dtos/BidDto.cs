namespace FinesseApp.Common.Dtos;

public class BidDto
{
	public int Id { get; set; }
	public string VendorId { get; set; } = default!;
	public int ProjectId { get; set; }
	public decimal Amount { get; set; }
	public DateTime SubmittedAt { get; set; }
}
