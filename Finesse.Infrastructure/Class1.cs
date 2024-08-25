using FinesseApp.Common.Models;

namespace Finesse.Infrastructure;

public class ApplicationDbContextSeed
{
	public static void Seed(ApplicationDbContext.ApplicationDbContext context)
	{
		// Ensure the database is created
		context.Database.EnsureCreated();

	
		if (!context.Vendors.Any())
		{
			context.Vendors.AddRange(
				new Vendor { Id = "1", Name = "Vendor One", Email = "vendor1@example.com", Password = "password", RegisteredAt = DateTime.Now},
				new Vendor { Id = "2", Name = "Vendor Two", Email = "vendor2@example.com", Password = "password", RegisteredAt = DateTime.Now }
			);

			
			context.Projects.AddRange(
				new Project { Id = 1, Title = "Project One", Description = "Description for Project One", Deadline = DateTime.Now },
				new Project { Id = 2, Title = "Project Two", Description = "Description for Project Two", Deadline = DateTime.Now}
			);

			context.SaveChanges();
		}
	}
}
