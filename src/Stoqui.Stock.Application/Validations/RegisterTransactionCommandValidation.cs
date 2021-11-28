using FluentValidation;
using Stoqui.Stock.Application.Commands;

namespace Stoqui.Stock.Application.Validations;

public class RegisterTransactionCommandValidation : AbstractValidator<RegisterTransactionCommand>
{
    public RegisterTransactionCommandValidation()
    {
        RuleFor(p => p.Description)
            .NotEmpty()
            .WithMessage("Description is required");

        RuleFor(p => p.Stockist)
            .NotEmpty()
            .WithMessage("Stockist is required");

        RuleFor(p => p.Requester)
            .NotEmpty()
            .WithMessage("Requester is required");
    }
}

