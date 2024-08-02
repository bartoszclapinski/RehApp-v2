using FluentValidation;

namespace RehApp.Application.Patient.Commands.UpdatePatient;

public class UpdatePatientCommandValidator : AbstractValidator<UpdatePatientCommand>
{
	public UpdatePatientCommandValidator()
	{
		RuleFor(x => x.FirstName).NotEmpty();
		RuleFor(x => x.LastName).NotEmpty();
		RuleFor(x => x.DateOfBirth).NotEmpty();
		RuleFor(x => x.ConditionDescription).NotEmpty();
		RuleFor(x => x.Address).NotNull();
		RuleFor(x => x.Pesel).NotEmpty();
		RuleFor(x => x.PhoneNumber).NotEmpty();
	}
}