using AutoMapper;
using RehApp.Application.User.Commands;
using RehApp.Domain.Entities;
using RehApp.Domain.Entities.Users;

namespace RehApp.Application.User.Profiles;

public class ApplicationUserProfile : Profile
{
	public ApplicationUserProfile()
	{

		CreateMap<CreateUserCommand, ApplicationUser>()
			.ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
			.ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
			.ForMember(dest => dest.IsActive, opt => opt.MapFrom(_ => true))
			.ForMember(dest => dest.Address, opt => opt.MapFrom(src => new Address
			{
				Street = src.Street,
				City = src.City,
				ZipCode = src.ZipCode,
				Country = src.Country
			}))
			.ForMember(dest => dest.LastLoginAt, opt => opt.Ignore())
			.ForMember(dest => dest.Id, opt => opt.Ignore())
			.ForMember(dest => dest.NormalizedEmail, opt => opt.Ignore())
			.ForMember(dest => dest.NormalizedUserName, opt => opt.Ignore())
			.ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
			.ForMember(dest => dest.SecurityStamp, opt => opt.Ignore())
			.ForMember(dest => dest.ConcurrencyStamp, opt => opt.Ignore())
			.ForMember(dest => dest.PhoneNumber, opt => opt.Ignore())
			.ForMember(dest => dest.PhoneNumberConfirmed, opt => opt.Ignore())
			.ForMember(dest => dest.TwoFactorEnabled, opt => opt.Ignore())
			.ForMember(dest => dest.LockoutEnd, opt => opt.Ignore())
			.ForMember(dest => dest.LockoutEnabled, opt => opt.Ignore())
			.ForMember(dest => dest.AccessFailedCount, opt => opt.Ignore());
	}
}