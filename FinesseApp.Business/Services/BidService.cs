using FinesseApp.Common.Interfaces;
using FinesseApp.Common.Interfaces.Services;
using FinesseApp.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace FinesseApp.Business.Services;

public class BidService : IBidService
{
	private readonly IUnitOfWork unitOfWork;

	public BidService(IUnitOfWork unitOfWork)
		{
		this.unitOfWork = unitOfWork;
	}

	public async Task<Bid> SubmitBidAsync(Bid bid)
	{
		await unitOfWork.Bids.AddAsync(bid);
		await unitOfWork.CompleteAsync();
		return bid;
	}

	public async Task<IEnumerable<Bid>> GetBidsByVendorIdAsync(string vendorId)
	{
		return await unitOfWork.Bids.Find(b => b.VendorId == vendorId).ToListAsync();
	}

}
