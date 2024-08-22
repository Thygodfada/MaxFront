using Finesse.Infrastructure.ApplicationDbContext;
using Finesse.Infrastructure.Repositories;
using FinesseApp.Business.Services;
using FinesseApp.Common.Interfaces;
using FinesseApp.Common.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FinesseApp.Business;

public class DIConfiguration
{
	public static void RegisterServices(IServiceCollection services)
	{
		services.AddDbContext<ApplicationDbContext>(options =>
			options.UseInMemoryDatabase("FinesseDb"));
		services.AddScoped<IUnitOfWork, UnitOfWork>();
		services.AddScoped<IVendorService, VendorService>();
		services.AddScoped<IProjectService, ProjectService>();
		services.AddScoped<IBidService, BidService>();
	}
}
