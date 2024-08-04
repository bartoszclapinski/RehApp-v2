using FluentValidation;

namespace RehApp.Application.Account.Commands.ChangePassword;

public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
{
	public ChangePasswordCommandValidator()
	{
		RuleFor(x => x.Id).NotEmpty();
		RuleFor(x => x.CurrentPassword).NotEmpty();
		RuleFor(x => x.NewPassword).NotEmpty().MinimumLength(6);
	}
}