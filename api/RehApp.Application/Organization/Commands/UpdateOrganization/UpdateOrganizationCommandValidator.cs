using FluentValidation;

namespace RehApp.Application.Organization.Commands.UpdateOrganization;

public class UpdateOrganizationCommandValidator : AbstractValidator<UpdateOrganizationCommand>
{
	public UpdateOrganizationCommandValidator()
	{
		RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
		RuleFor(x => x.Description).NotEmpty().MaximumLength(500);

		RuleFor(x => x.Address).NotNull();
		RuleFor(x => x.Address.Street).NotEmpty().MaximumLength(100);
		RuleFor(x => x.Address.City).NotEmpty().MaximumLength(50);
		RuleFor(x => x.Address.ZipCode).NotEmpty()
			.Matches(@"^\d{2}-\d{3}$").WithMessage("Zip code must be in the format XX-XXX.");
		RuleFor(x => x.Address.Country).NotEmpty().MaximumLength(50);

		RuleFor(x => x.Phone).NotEmpty().MaximumLength(15);
		RuleFor(x => x.Email).NotEmpty().EmailAddress().MaximumLength(100);
		RuleFor(x => x.AdditionalInfo).MaximumLength(1000);
	}
}