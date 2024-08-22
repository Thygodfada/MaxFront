using FinesseApp.Common.Dtos;
using FinesseApp.Common.Interfaces.Services;
using FinesseApp.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinesseApp.Api.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class VendorController : ControllerBase
	{
		private readonly IVendorService _vendorService;

		public VendorController(IVendorService vendorService)
		{
			_vendorService = vendorService;
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetVendorById(int id)
		{
			var vendor = await _vendorService.GetVendorByIdAsync(id);
			if (vendor == null)
			{
				return NotFound();
			}
			var vendorDto = new VendorDto
			{
				Id = vendor.Id,
				Name = vendor.Name,
				Email = vendor.Email
			};

			return Ok(vendorDto);
		}

		[HttpGet]
		public async Task<IActionResult> GetAllVendors()
		{
			var vendors = await _vendorService.GetAllVendorsAsync();
			var vendorDtos = vendors.Select(v => new VendorDto
			{
				Id = v.Id,
				Name = v.Name,
				Email = v.Email
			});

			return Ok(vendorDtos);
		}
	}
}
