
using FinesseApp.Common.Interfaces;

namespace Finesse.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
	private readonly ApplicationDbContext.ApplicationDbContext _context;

	public UnitOfWork(ApplicationDbContext.ApplicationDbContext context)
	{
		_context = context;
		Vendors = new VendorRepository(_context);
		Projects = new ProjectRepository(_context);
		Bids = new BidRepository(_context);
	}

	public IVendorRepository Vendors { get; private set; }
	public IProjectRepository Projects { get; private set; }
	public IBidRepository Bids { get; private set; }

	public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

	public void Dispose() => _context.Dispose();
}
