using FluentValidation;
using Stoqui.Stock.Application.Commands;

namespace Stoqui.Stock.Application.Validations;

public class RegisterProductCommandValidation : AbstractValidator<RegisterProductCommand>
{
    public RegisterProductCommandValidation()
    {
        RuleFor(p => p.Id)
            .NotEmpty()
            .WithMessage("ProductId is required");

        RuleFor(p => p.Name)
            .NotEmpty()
            .WithMessage("Product Name is required");
    }
}