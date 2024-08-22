using FinesseApp.Common.Models;

namespace FinesseApp.Common.Interfaces.Services;

public interface IBidService
{
	Task<Bid> SubmitBidAsync(Bid bid);
	Task<IEnumerable<Bid>> GetBidsByVendorIdAsync(int vendorId);
}
