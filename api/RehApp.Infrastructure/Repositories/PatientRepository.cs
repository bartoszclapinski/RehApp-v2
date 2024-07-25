using Microsoft.EntityFrameworkCore;
using RehApp.Domain.Entities.Patients;
using RehApp.Domain.Interfaces;
using RehApp.Infrastructure.Data;

namespace RehApp.Infrastructure.Repositories;

public class PatientRepository(ApplicationDbContext context) : IPatientRepository
{

	public async Task<Patient?> GetByIdAsync(Guid id)
	{
		Patient? patient = await context.Patients
			.Include(p => p.Address)
			.FirstOrDefaultAsync(p => p.Id == id);

		return patient;
	}

	public async Task<Patient> AddAsync(Patient patient)
	{
		await context.Patients.AddAsync(patient);
		await context.SaveChangesAsync();

		return patient;
	}
}