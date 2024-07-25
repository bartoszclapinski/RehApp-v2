using AutoMapper;
using RehApp.Application.DTOs;
using RehApp.Application.Patient.Commands.CreatePatient;
using RehApp.Application.Patient.Queries.GetPatientById;
using RehApp.Domain.Entities;
using DomainPatient = RehApp.Domain.Entities.Patients.Patient;

namespace RehApp.Application.Patient.Profiles;

public class PatientProfile : Profile
{
	public PatientProfile()
	{
		CreateMap<CreatePatientCommand, DomainPatient>()
			.ForMember(dest => dest.Address, opt => opt.MapFrom(src => new Address
			{
				Street = src.Street,
				City = src.City,
				ZipCode = src.ZipCode,
				Country = src.Country
			}));

		CreateMap<DomainPatient, PatientDto>()
			.ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));
		CreateMap<Address, AddressDto>();
	}
}