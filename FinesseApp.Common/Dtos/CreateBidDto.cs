namespace FinesseApp.Common.Dtos;

public class CreateBidDto
{
	public string VendorId { get; set; } = default!;
	public int ProjectId { get; set; }
	public decimal Amount { get; set; }
}
