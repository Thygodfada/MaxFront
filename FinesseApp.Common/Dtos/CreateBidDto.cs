namespace FinesseApp.Common.Dtos;

public class CreateBidDto
{
	public int VendorId { get; set; }
	public int ProjectId { get; set; }
	public decimal Amount { get; set; }
}
