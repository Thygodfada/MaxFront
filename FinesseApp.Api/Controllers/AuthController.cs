using FinesseApp.Common.Dtos;
using FinesseApp.Common.Interfaces.Services;
using FinesseApp.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FinesseApp.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IVendorService _vendorService;
		private readonly IConfiguration _configuration;

		public AuthController(IVendorService vendorService, IConfiguration configuration)
		{
			_vendorService = vendorService;
			_configuration = configuration;
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] VendorLoginDto loginDto)
		{
			var vendor = await _vendorService.AuthenticateAsync(loginDto.Email, loginDto.Password);
			if (vendor == null)
			{
				return Unauthorized();
			}

			var token = GenerateJwtToken(vendor);
			return Ok(new { token });
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] VendorRegistrationDto registrationDto)
		{
			try
			{
				var vendor = await _vendorService.RegisterAsync(registrationDto);
				return Ok(new { vendor.Id, vendor.Email });
			}
			catch (InvalidOperationException ex)
			{
				return BadRequest(new { message = ex.Message });
			}
		}

		private string GenerateJwtToken(Vendor vendor)
		{
			var claims = new[]
			{
				new Claim(JwtRegisteredClaimNames.Sub, vendor.Email),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new Claim(ClaimTypes.NameIdentifier, vendor.Id.ToString())
			};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				issuer: _configuration["Jwt:Issuer"],
				audience: _configuration["Jwt:Audience"],
				claims: claims,
				expires: DateTime.Now.AddMinutes(30),
				signingCredentials: creds);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}

