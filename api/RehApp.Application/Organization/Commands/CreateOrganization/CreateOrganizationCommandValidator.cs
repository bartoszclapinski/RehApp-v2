using FluentValidation;

namespace RehApp.Application.Organization.Commands.CreateOrganization;

public class CreateOrganizationCommandValidator : AbstractValidator<CreateOrganizationCommand>
{
	public CreateOrganizationCommandValidator()
	{
		RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
		RuleFor(x => x.Description).NotEmpty().MaximumLength(500);

		// Address validation
		RuleFor(x => x.Street).NotEmpty().MaximumLength(100);
		RuleFor(x => x.City).NotEmpty().MaximumLength(50);
		RuleFor(x => x.ZipCode).NotEmpty()
			.Matches(@"^\d{2}-\d{3}$").WithMessage("Zip code must be in the format XX-XXX.");
		RuleFor(x => x.Country).NotEmpty().MaximumLength(50);
	}
}