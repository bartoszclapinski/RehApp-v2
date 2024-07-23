using Microsoft.Extensions.DependencyInjection;
using RehApp.Application.User;

namespace RehApp.Application.Extensions;

public static class ServiceCollectionExtensions
{
	public static void AddApplication(this IServiceCollection services)
	{
		services.AddAutoMapper(typeof(ServiceCollectionExtensions).Assembly);
		services.AddScoped<IUserContext, UserContext>();
		services.AddHttpContextAccessor();
		
	}
}