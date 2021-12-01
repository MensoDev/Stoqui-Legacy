using FluentValidation;
using Stoqui.Stock.Application.Commands;

namespace Stoqui.Stock.Application.Validations
{
    public class RegisterTransactionItemCommandValidation : AbstractValidator<RegisterTransactionItemCommand>
    {
        public RegisterTransactionItemCommandValidation()
        {
            RuleFor(p => p.TopicId)
                .NotEmpty()
                .WithMessage("TopicId is required for register a new TransactionItem");

            RuleFor(p => p.TransactionId)
                .NotEmpty()
                .WithMessage("TransactionId is required for register a new TransactionItem");

            RuleFor(p => p.ProductId)
                .NotEmpty()
                .WithMessage("ProductId is required for register a new TransactionItem");

            RuleFor(p => p.Amount)
                .GreaterThan(ushort.MinValue)
                .WithMessage("Amount must have a value greater than zero");
        }
    }
}
