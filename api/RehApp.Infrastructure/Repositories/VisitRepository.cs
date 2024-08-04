using Microsoft.EntityFrameworkCore;
using RehApp.Domain.Entities.Patients;
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
	
	public async Task<Visit?> GetByIdOnlyVisitAsync(Guid id)
	{
		Visit? visit = await context.Visits
			.FirstOrDefaultAsync(v => v.Id == id);

		return visit;
	}

	public async Task<Visit> AddAsync(Visit visit)
	{
		await context.Visits.AddAsync(visit);
		await context.SaveChangesAsync();

		return visit;
	}

	public async Task<IEnumerable<Visit>> GetVisitsByUserForOrganizationAsync(string userId, Guid organizationId)
	{
		return await context.Visits
			.Include(v => v.Patient)
			.Include(v => v.CreatedByUser)
			.Where(v => v.CreatedByUserId == userId && v.OrganizationId == organizationId)
			.OrderByDescending(v => v.Date)
			.ToListAsync();
	}
	
	public async Task<IEnumerable<Visit>> GetVisitsByPatientIdForUserAsync(Guid patientId, string userId)
	{
		return await context.Visits
			.Include(v => v.Patient)
			.Include(v => v.CreatedByUser)
			.Where(v => v.PatientId == patientId && v.CreatedByUserId == userId)
			.OrderByDescending(v => v.Date)
			.ToListAsync();

	}
	
	public async Task<List<Visit>> GetAllVisitsForOrganizationAsync(Guid organizationId)
	{
		return await context.Visits
			.Include(v => v.Patient)
			.Include(v => v.CreatedByUser)
			.Where(v => v.OrganizationId == organizationId)
			.ToListAsync();
	}
	
	public async Task DeleteAsync(Visit visit)
	{
		context.Visits.Remove(visit);
		await context.SaveChangesAsync();
	}
	
	public async Task UpdateAsync(Visit visit)
	{
		context.Visits.Update(visit);
		await context.SaveChangesAsync();
	}
}