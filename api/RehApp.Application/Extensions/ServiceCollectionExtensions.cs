using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using RehApp.Application.User;

namespace RehApp.Application.Extensions;

public static class ServiceCollectionExtensions
{
	public static void AddApplication(this IServiceCollection services)
	{
		Assembly assembly = typeof(ServiceCollectionExtensions).Assembly;
		services.AddAutoMapper(assembly);
		services.AddValidatorsFromAssembly(assembly).AddFluentValidationAutoValidation();
		services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
		
		services.AddScoped<IUserContext, UserContext>();
		services.AddHttpContextAccessor();
	}
}