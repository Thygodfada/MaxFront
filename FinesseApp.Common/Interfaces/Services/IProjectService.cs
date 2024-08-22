using FinesseApp.Common.Models;

namespace FinesseApp.Common.Interfaces.Services;

public interface IProjectService
{
	Task<IEnumerable<Project>> GetAllProjectsAsync();
	Task<Project> GetProjectByIdAsync(int id);
	Task<Project> CreateProjectAsync(Project project);
}
