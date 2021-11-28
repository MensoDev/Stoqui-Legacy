using FluentValidation;
using Stoqui.Stock.Application.Commands;

namespace Stoqui.Stock.Application.Validations;

public class RegisterTransactionTopicCommandValidation : AbstractValidator<RegisterTransactionTopicCommand>
{
    public RegisterTransactionTopicCommandValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Topic Name is required for register");

    }
}

