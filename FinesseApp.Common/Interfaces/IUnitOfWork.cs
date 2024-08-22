namespace FinesseApp.Common.Interfaces;

public interface IUnitOfWork : IDisposable
{
	IVendorRepository Vendors { get; }
	IProjectRepository Projects { get; }
	IBidRepository Bids { get; }
	Task<int> CompleteAsync();

}
