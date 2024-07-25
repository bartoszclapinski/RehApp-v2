// RehApp.Application/Visit/MappingProfiles/VisitProfile.cs

using AutoMapper;
using RehApp.Application.DTOs;
using RehApp.Application.Visit.Commands.CreateVisit;
using DomainVisit = RehApp.Domain.Entities.Visits.Visit;

namespace RehApp.Application.Visit.Profiles;

public class VisitProfile : Profile
{
	public VisitProfile()
	{
		CreateMap<CreateVisitCommand, DomainVisit>();
		CreateMap<DomainVisit, VisitDto>()
			.ForMember(dest => dest.CreatedByUserId, opt => opt.MapFrom(src => src.CreatedByUserId))
			.ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => $"{src.Patient.FirstName} {src.Patient.LastName}"))
			.ForMember(dest => dest.OrganizationName, opt => opt.MapFrom(src => src.Organization.Name));
	}
}