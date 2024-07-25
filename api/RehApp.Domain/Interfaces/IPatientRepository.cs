using RehApp.Domain.Entities.Patients;

namespace RehApp.Domain.Interfaces;

public interface IPatientRepository
{
	Task<Patient?> GetByIdAsync(Guid id);
	Task<Patient> AddAsync(Patient patient);
}