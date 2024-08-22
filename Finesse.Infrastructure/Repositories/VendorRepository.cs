using FinesseApp.Common.Interfaces;
using FinesseApp.Common.Models;

namespace Finesse.Infrastructure.Repositories;

public class VendorRepository : GenericRepository<Vendor>, IVendorRepository
{
	public VendorRepository(ApplicationDbContext.ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }
}
