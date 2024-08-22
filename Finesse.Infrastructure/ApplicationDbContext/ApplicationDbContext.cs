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
			modelBuilder.Entity<Vendor>()
				.HasMany(v => v.Bids)
				.WithOne(b => b.Vendor)
				.HasForeignKey(b => b.VendorId);

			modelBuilder.Entity<Project>()
				.HasMany(p => p.Bids)
				.WithOne(b => b.Project)
				.HasForeignKey(b => b.ProjectId);
		}
}
