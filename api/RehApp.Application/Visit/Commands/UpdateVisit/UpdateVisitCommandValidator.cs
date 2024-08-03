using FluentValidation;

namespace RehApp.Application.Visit.Commands.UpdateVisit;

public class UpdateVisitCommandValidator : AbstractValidator<UpdateVisitCommand>
{
	public UpdateVisitCommandValidator()
	{
		RuleFor(x => x.Id).NotEmpty();
		RuleFor(x => x.Date).NotEmpty();
		RuleFor(x => x.Description).NotEmpty();
	}
}