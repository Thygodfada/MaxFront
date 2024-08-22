
using FinesseApp.Common.Dtos;
using FinesseApp.Common.Interfaces.Services;
using FinesseApp.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinesseApp.Api.Controllers;
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class BidController : ControllerBase
{
	private readonly IBidService _bidService;

	public BidController(IBidService bidService)
	{
		_bidService = bidService;
	}

	[HttpPost]
	public async Task<IActionResult> SubmitBid([FromBody] CreateBidDto createBidDto)
	{
		if (createBidDto == null)
		{
			return BadRequest("Bid cannot be null.");
		}

		var bid = new Bid
		{
			VendorId = createBidDto.VendorId,
			ProjectId = createBidDto.ProjectId,
			Amount = createBidDto.Amount,
			SubmittedAt = DateTime.UtcNow
		};

		var createdBid = await _bidService.SubmitBidAsync(bid);
		var bidDto = new BidDto
		{
			Id = createdBid.Id,
			VendorId = createdBid.VendorId,
			ProjectId = createdBid.ProjectId,
			Amount = createdBid.Amount,
			SubmittedAt = createdBid.SubmittedAt
		};

		return CreatedAtAction(nameof(GetBidsByVendorId), new { vendorId = bidDto.VendorId }, bidDto);

	}


	[HttpGet("{vendorId}")]
	public async Task<IActionResult> GetBidsByVendorId(int vendorId)
	{
		var bids = await _bidService.GetBidsByVendorIdAsync(vendorId);
			if (bids == null || !bids.Any())
			{
				return NotFound();
			}

			var bidDtos = bids.Select(b => new BidDto
			{
				Id = b.Id,
				VendorId = b.VendorId,
				ProjectId = b.ProjectId,
				Amount = b.Amount,
				SubmittedAt = b.SubmittedAt
			});

			return Ok(bidDtos);
	}
}
