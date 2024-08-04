using AutoMapper;
using RehApp.Application.DTOs.VisitDTOs;
using RehApp.Application.Visit.Commands.CreateVisit;
using RehApp.Application.Visit.Commands.UpdateVisit;
using RehApp.Domain.Entities.Users;
using DomainVisit = RehApp.Domain.Entities.Visits.Visit;
using DomainPatient = RehApp.Domain.Entities.Patients.Patient;

namespace RehApp.Application.Visit.Profiles;

public class VisitProfile : Profile
{
	public VisitProfile()
	{
		CreateMap<CreateVisitCommand, DomainVisit>();
		CreateMap<DomainVisit, VisitForListDto>()
			.ForMember(dest => dest.Patient, opt => opt.MapFrom(src => src.Patient))
			.ForMember(dest => dest.User, opt => opt.MapFrom(src => src.CreatedByUser));

		CreateMap<ApplicationUser, BaseUserForVisitListDto>();
		CreateMap<DomainPatient, PatientForVisitListDto>();
		CreateMap<DomainVisit, VisitDto>()
			.ForMember(dest => dest.Patient, opt => opt.MapFrom(src => src.Patient))
			.ForMember(dest => dest.User, opt => opt.MapFrom(src => src.CreatedByUser));
		
		CreateMap<UpdateVisitCommand, DomainVisit>();
		
	}
}