using Microsoft.EntityFrameworkCore;
using RehApp.Domain.Entities.Visits;
using RehApp.Domain.Interfaces;
using RehApp.Infrastructure.Data;

namespace RehApp.Infrastructure.Repositories;

public class VisitRepository(ApplicationDbContext context) : IVisitRepository
{

	public async Task<Visit?> GetByIdAsync(Guid id)
	{
		Visit? visit = await context.Visits
			.Include(v => v.Patient)
			.Include(v => v.CreatedByUser)
			.Include(v => v.Organization)
			.FirstOrDefaultAsync(v => v.Id == id);

		return visit;
	}

	public async Task<Visit> AddAsync(Visit visit)
	{
		await context.Visits.AddAsync(visit);
		await context.SaveChangesAsync();

		return visit;
	}
}