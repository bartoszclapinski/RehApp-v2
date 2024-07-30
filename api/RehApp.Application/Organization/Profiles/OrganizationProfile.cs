using AutoMapper;
using RehApp.Application.DTOs;
using RehApp.Application.Organization.Commands.CreateOrganization;
using RehApp.Application.Organization.Commands.UpdateOrganization;
using RehApp.Domain.Entities;
using DomainOrganization = RehApp.Domain.Entities.Organizations.Organization;

namespace RehApp.Application.Organization.Profiles;

public class OrganizationProfile : Profile
{
	public OrganizationProfile()
	{
		CreateMap<CreateOrganizationCommand, DomainOrganization>()
			.ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
			.ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
			.ForMember(dest => dest.Address, opt => opt.MapFrom(src => new Address
			{
				Street = src.Street,
				City = src.City,
				ZipCode = src.ZipCode,
				Country = src.Country
			}));

		CreateMap<DomainOrganization, OrganizationDto>();
		CreateMap<Address, AddressDto>();
		CreateMap<AddressDto, Address>();
		CreateMap<UpdateOrganizationCommand, DomainOrganization>();
	}
}