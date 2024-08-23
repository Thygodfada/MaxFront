using FinesseApp.Common.Dtos;
using FinesseApp.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace Finesse.Infrastructure.ApplicationDbContext;

public class ApplicationDbContext : DbContext
{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

		public DbSet<Vendor> Vendors { get; set; }
		public DbSet<Project> Projects { get; set; }
		public DbSet<Bid> Bids { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{

		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<Vendor>()
			.HasMany(v => v.Bids)
			.WithOne(b => b.Vendor)
			.HasForeignKey(b => b.VendorId);

		modelBuilder.Entity<Project>()
			.HasMany(p => p.Bids)
			.WithOne(b => b.Project)
			.HasForeignKey(b => b.ProjectId);


		// Seed Vendors
		/*var vendorId = 1;
		var vendor = new Vendor
		{
			Id = vendorId,
			Name = "Vendor",
			Email = "Test@test.com",
			Password = "Password",
			RegisteredAt = DateTime.Now
		};
		modelBuilder.Entity<Vendor>().HasData(vendor);


		// Seed Projects
		var projectId = 1;
		var project = new Project
		{
			Id = projectId,
			Title = "Test Project",
			Description = "Testing Description",
			Deadline = DateTime.Now
		};
			modelBuilder.Entity<Project>().HasData(project);

		*/

	}
}
