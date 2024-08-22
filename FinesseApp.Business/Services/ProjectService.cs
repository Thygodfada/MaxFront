using FinesseApp.Common.Interfaces;
using FinesseApp.Common.Interfaces.Services;
using FinesseApp.Common.Models;

namespace FinesseApp.Business.Services;

public class ProjectService : IProjectService
{
	private readonly IUnitOfWork unitOfWork;

	public ProjectService(IUnitOfWork unitOfWork)
	{
		this.unitOfWork = unitOfWork;
	}

	public async Task<IEnumerable<Project>> GetAllProjectsAsync() => await unitOfWork.Projects.GetAllAsync();

	public async Task<Project> GetProjectByIdAsync(int id) => await unitOfWork.Projects.GetByIdAsync(id);

	public async Task<Project> CreateProjectAsync(Project project)
	{
		await unitOfWork.Projects.AddAsync(project);
		await unitOfWork.CompleteAsync();
		return project;
	}



}
