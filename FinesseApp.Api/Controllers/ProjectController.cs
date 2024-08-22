using FinesseApp.Business.Services;
using FinesseApp.Common.Dtos;
using FinesseApp.Common.Interfaces.Services;
using FinesseApp.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinesseApp.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProjectController : ControllerBase
	{
		private readonly IProjectService _projectService;

		public ProjectController(IProjectService projectService)
		{
			_projectService = projectService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllProjects()
		{
			var projects = await _projectService.GetAllProjectsAsync();
			var projectDto = projects.Select(p => new ProjectDto
			{
				Id = p.Id,
				Title = p.Title,
				Description = p.Description,
				Deadline = p.Deadline
			});

			return Ok(projectDto);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetProjectById(int id)
		{
			var project = await _projectService.GetProjectByIdAsync(id);
			if (project == null)
			{
				return NotFound();
			}

			var projectDto = new ProjectDto
			{
				Id = project.Id,
				Title = project.Title,
				Description = project.Description,
				Deadline = project.Deadline
			};

			return Ok(projectDto);
		}


		[HttpPost]
		public async Task<IActionResult> CreateProject([FromBody] CreateProjectDto createdproject)
		{
			if (createdproject == null)
			{
				return BadRequest("Project cannot be null.");
			}
			var project = new Project
			{
				Title = createdproject.Title,
				Description = createdproject.Description,
				Deadline = createdproject.Deadline
			};


			var createdProject = await _projectService.CreateProjectAsync(project);
			var projectDto = new ProjectDto
			{
				Id = createdProject.Id,
				Title = createdProject.Title,
				Description = createdProject.Description,
				Deadline = createdproject.Deadline
			};

			return CreatedAtAction(nameof(GetProjectById), new { id = projectDto.Id }, projectDto);
		}
	}
}
