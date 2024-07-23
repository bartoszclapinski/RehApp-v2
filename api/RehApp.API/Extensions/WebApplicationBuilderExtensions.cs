using Microsoft.OpenApi.Models;
using RehApp.Domain.Entities.Users;
using RehApp.Infrastructure.Data;

namespace RehApp.API.Extensions;

public static class WebApplicationBuilderExtensions
{
	public static void AddPresentation(this WebApplicationBuilder builder)
	{
		builder.Services.AddAuthentication();
		builder.Services.AddControllers();
		builder.Services.AddEndpointsApiExplorer();

		builder.Services.AddSwaggerGen(o =>
		{
			o.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
			{
				Type = SecuritySchemeType.Http,
				Scheme = "Bearer"
			});
	
			o.AddSecurityRequirement(new OpenApiSecurityRequirement 
			{
				{
					new OpenApiSecurityScheme
					{
						Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "bearerAuth" }
					},
					[]
				} 
			});
		});

		builder.Services.AddIdentityApiEndpoints<ApplicationUser>()
			.AddEntityFrameworkStores<ApplicationDbContext>();
	}
}