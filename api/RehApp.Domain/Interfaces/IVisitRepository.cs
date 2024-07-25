using RehApp.Domain.Entities.Visits;

namespace RehApp.Domain.Interfaces;

public interface IVisitRepository
{
	Task<Visit?> GetByIdAsync(Guid id);
	Task<Visit> AddAsync(Visit visit);
}