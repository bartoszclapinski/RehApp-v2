using RehApp.API.Extensions;
using RehApp.Application.Extensions;
using RehApp.Domain.Entities.Users;
using RehApp.Infrastructure.Extensions;
using RehApp.Infrastructure.Seeders;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddPresentation();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

WebApplication app = builder.Build();

IServiceScope scope = app.Services.CreateScope();
await scope.ServiceProvider.GetRequiredService<IDataSeed>().Seed();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();

app.MapGroup("api/identity").WithTags("Identity").MapIdentityApi<ApplicationUser>();

app.UseAuthorization();

app.MapControllers();

app.Run();
