using Finesse.Infrastructure.Repositories;
using FinesseApp.Common.Dtos;
using FinesseApp.Common.Interfaces;
using FinesseApp.Common.Interfaces.Services;
using FinesseApp.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace FinesseApp.Business.Services
{
	public class VendorService : IVendorService
	{
		private readonly IUnitOfWork unitOfWork;

		public VendorService(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public async Task<IEnumerable<Vendor>> GetAllVendorsAsync() => await unitOfWork.Vendors.GetAllAsync();

		public async Task<Vendor> GetVendorByIdAsync(int id) => await unitOfWork.Vendors.GetByIdAsync(id);

		public async Task<Vendor> CreateVendorAsync(Vendor vendor)
		{
			await unitOfWork.Vendors.AddAsync(vendor);
			await unitOfWork.CompleteAsync();
			return vendor;
		}

		public async Task<Vendor> AuthenticateAsync(string email, string password)
		{
			var vendor = await unitOfWork.Vendors.Find(v => v.Email == email && v.Password == password).FirstOrDefaultAsync();
			return vendor;
		}
		public async Task<Vendor> RegisterAsync(VendorRegistrationDto registrationDto)
		{
			// Check if the email is already in use
			var existingVendor = await unitOfWork.Vendors
				.Find(v => v.Email == registrationDto.Email)
				.FirstOrDefaultAsync();

			if (existingVendor != null)
			{
				throw new InvalidOperationException("Email is already in use.");
			}

			// Create a new vendor entity
			var vendor = new Vendor
			{
				Name = registrationDto.Name,
				Email = registrationDto.Email,
				Password = registrationDto.Password, // In a real application, hash the password
				RegisteredAt = DateTime.UtcNow
			};

			// Add and save the vendor
			await unitOfWork.Vendors.AddAsync(vendor);
			await unitOfWork.CompleteAsync();

			return vendor;
		}
	}
}
