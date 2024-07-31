using FluentValidation;

namespace RehApp.Application.Organization.Commands.CreateOrganization;

public class CreateOrganizationCommandValidator : AbstractValidator<CreateOrganizationCommand>
{
	public CreateOrganizationCommandValidator()
	{
		RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
		RuleFor(x => x.Description).NotEmpty().MaximumLength(500);
		RuleFor(x => x.Street).NotEmpty().MaximumLength(100);
		RuleFor(x => x.City).NotEmpty().MaximumLength(50);
		RuleFor(x => x.ZipCode).NotEmpty().Matches(@"^\d{2}-\d{3}$");
		RuleFor(x => x.Country).NotEmpty().MaximumLength(50);
		RuleFor(x => x.Phone).NotEmpty().MaximumLength(15);
		RuleFor(x => x.Email).NotEmpty().MaximumLength(100);
		RuleFor(x => x.TaxNumber).NotEmpty().MaximumLength(20); // New field
	}
}