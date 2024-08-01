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
			.ForMember(dest => dest.Address, opt => opt.MapFrom(src => new Address
			{
				Street = src.Street,
				City = src.City,
				ZipCode = src.ZipCode,
				Country = src.Country
			}));
		
		CreateMap<UpdateOrganizationCommand, DomainOrganization>()
			.ForMember(dest => dest.Address, opt => opt.MapFrom(src => new Address
			{
				Street = src.Address.Street,
				City = src.Address.City,
				ZipCode = src.Address.ZipCode,
				Country = src.Address.Country
			}));

		CreateMap<DomainOrganization, OrganizationDto>()
			.ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));
		CreateMap<Address, AddressDto>();
		CreateMap<AddressDto, Address>();
	}
}