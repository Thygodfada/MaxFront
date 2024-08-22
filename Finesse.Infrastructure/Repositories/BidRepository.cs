using FinesseApp.Common.Interfaces;
using FinesseApp.Common.Models;

namespace Finesse.Infrastructure.Repositories;

public class BidRepository : GenericRepository<Bid>, IBidRepository
{
    public BidRepository(ApplicationDbContext.ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }
   
}
