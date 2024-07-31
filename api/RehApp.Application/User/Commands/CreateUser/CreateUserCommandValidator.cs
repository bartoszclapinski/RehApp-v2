using System.Data;
using FluentValidation;
using RehApp.Domain.Constants;

namespace RehApp.Application.User.Commands.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
	public CreateUserCommandValidator()
	{
		RuleFor(x => x.Email).NotEmpty().EmailAddress();
		RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
		RuleFor(x => x.FirstName).NotEmpty().MaximumLength(100);
		RuleFor(x => x.LastName).NotEmpty().MaximumLength(100);
		RuleFor(x => x.Specialization).NotEmpty()
			.When(x => x.UserRole is UserRoles.Doctor or UserRoles.Physiotherapist);
		RuleFor(x => x.LicenseNumber).NotEmpty().MaximumLength(50)
			.When(x => x.UserRole is UserRoles.Doctor or UserRoles.Physiotherapist or UserRoles.Nurse);
		RuleFor(x => x.Department).NotEmpty().MaximumLength(50)
			.When(x => x.UserRole is UserRoles.Nurse);
		RuleFor(x => x.AdminLevel).NotEmpty().MaximumLength(50)
			.When(x => x.UserRole is UserRoles.OrganizationAdmin or UserRoles.Admin);
		RuleFor(x => x.PhoneNumber).NotEmpty().MaximumLength(15);
		
		RuleFor(x => x.Street).NotEmpty().MaximumLength(100);
		RuleFor(x => x.City).NotEmpty().MaximumLength(100);
		RuleFor(x => x.ZipCode).NotEmpty().MaximumLength(6);
		RuleFor(x => x.Country).NotEmpty().MaximumLength(50);
	}
}