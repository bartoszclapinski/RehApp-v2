
using FluentValidation;

namespace RehApp.Application.Patient.Commands.CreatePatient;

public class CreatePatientCommandValidator : AbstractValidator<CreatePatientCommand>
{
	public CreatePatientCommandValidator()
	{
		RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
		RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);
		RuleFor(x => x.DateOfBirth).NotEmpty().LessThan(DateTime.Now);
		RuleFor(x => x.ConditionDescription).NotEmpty().MaximumLength(1000);
		RuleFor(x => x.Street).NotEmpty().MaximumLength(100);
		RuleFor(x => x.City).NotEmpty().MaximumLength(50);
		RuleFor(x => x.ZipCode).NotEmpty().Matches(@"^\d{2}-\d{3}$");
		RuleFor(x => x.Country).NotEmpty().MaximumLength(50);
	}
}