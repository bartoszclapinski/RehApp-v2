using FluentValidation;
using RehApp.Application.User.DTOs;
using RehApp.Domain.Constants;

namespace RehApp.Application.User.Validators;

public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
{
	public CreateUserDtoValidator()
	{
		RuleFor(x => x.Email).NotEmpty().EmailAddress();
		RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
		RuleFor(x => x.FirstName).NotEmpty();
		RuleFor(x => x.LastName).NotEmpty();
		RuleFor(x => x.Specialization).NotEmpty()
			.When(x => x.Role is UserRoles.Doctor or UserRoles.Physiotherapist);
		RuleFor(x => x.LicenseNumber).NotEmpty()
			.When(x => x.Role is UserRoles.Doctor or UserRoles.Physiotherapist or UserRoles.Nurse);
		RuleFor(x => x.Department).NotEmpty()
			.When(x => x.Role is UserRoles.Nurse);
		RuleFor(x => x.AdminLevel).NotEmpty()
			.When(x => x.Role is UserRoles.OrganizationAdmin or UserRoles.Admin);
	}
}