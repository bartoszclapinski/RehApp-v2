using FluentValidation;
using RehApp.Domain.Constants;

namespace RehApp.Application.User.Commands;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
	public CreateUserCommandValidator()
	{
		RuleFor(x => x.Email).NotEmpty().EmailAddress();
		RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
		RuleFor(x => x.FirstName).NotEmpty();
		RuleFor(x => x.LastName).NotEmpty();
		RuleFor(x => x.Specialization).NotEmpty()
			.When(x => x.UserRole is UserRoles.Doctor or UserRoles.Physiotherapist);
		RuleFor(x => x.LicenseNumber).NotEmpty()
			.When(x => x.UserRole is UserRoles.Doctor or UserRoles.Physiotherapist or UserRoles.Nurse);
		RuleFor(x => x.Department).NotEmpty()
			.When(x => x.UserRole is UserRoles.Nurse);
		RuleFor(x => x.AdminLevel).NotEmpty()
			.When(x => x.UserRole is UserRoles.OrganizationAdmin or UserRoles.Admin);
	}
}