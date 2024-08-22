using FinesseApp.Common.Dtos;
using FinesseApp.Common.Models;

namespace FinesseApp.Common.Interfaces.Services;

public interface IVendorService
{
	Task<Vendor> AuthenticateAsync(string email, string password);
	Task<IEnumerable<Vendor>> GetAllVendorsAsync();
	Task<Vendor> GetVendorByIdAsync(int id);
	Task<Vendor> CreateVendorAsync(Vendor vendor);
	Task<Vendor> RegisterAsync(VendorRegistrationDto registrationDto);
}
