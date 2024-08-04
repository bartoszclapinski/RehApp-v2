using FluentValidation;

namespace RehApp.Application.Visit.Commands.DeleteVisit;

public class DeleteVisitCommandValidator : AbstractValidator<DeleteVisitCommand>
{
	public DeleteVisitCommandValidator()
	{
		RuleFor(x => x.Id).NotEmpty();
	}
}