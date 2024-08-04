using RehApp.Domain.Entities.Visits;

namespace RehApp.Domain.Interfaces;

public interface IVisitRepository
{
	Task<Visit?> GetByIdAsync(Guid id);
	Task<Visit?> GetByIdOnlyVisitAsync(Guid id);
	Task<Visit> AddAsync(Visit visit);
	Task<IEnumerable<Visit>> GetVisitsByUserForOrganizationAsync(string userId, Guid organizationId);
	Task<IEnumerable<Visit>> GetVisitsByPatientIdForUserAsync(Guid patientId, string userId);
	Task<List<Visit>> GetAllVisitsForOrganizationAsync(Guid organizationId);
	Task DeleteAsync(Visit visit);
	Task UpdateAsync(Visit visit);
	
}