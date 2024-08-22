using FinesseApp.Common.Interfaces;
using FinesseApp.Common.Models;

namespace Finesse.Infrastructure.Repositories;

public class ProjectRepository : GenericRepository<Project>, IProjectRepository
{
    public ProjectRepository(ApplicationDbContext.ApplicationDbContext applicationDbContext) : base(applicationDbContext){}
}
