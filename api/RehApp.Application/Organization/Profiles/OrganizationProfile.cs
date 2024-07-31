﻿using AutoMapper;
using RehApp.Application.DTOs;
using RehApp.Application.Organization.Commands.CreateOrganization;
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

		CreateMap<DomainOrganization, OrganizationDto>()
			.ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));
		CreateMap<Address, AddressDto>();
	}
}