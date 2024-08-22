namespace FinesseApp.Common.Dtos;

public class BidDto
{
	public int Id { get; set; }
	public int VendorId { get; set; }
	public int ProjectId { get; set; }
	public decimal Amount { get; set; }
	public DateTime SubmittedAt { get; set; }
}
