using Stoqui.Kernel.Domain.Messages;
using Stoqui.Stock.Application.Validations;

namespace Stoqui.Stock.Application.Commands;

public class RegisterTransactionItemCommand : Command
{
    public RegisterTransactionItemCommand(
        Guid transactionId, 
        Guid productId, 
        ushort amount, 
        Guid topicId)
    {
        TransactionId = transactionId;
        ProductId = productId;
        Amount = amount;
        TopicId = topicId;
    }

    public Guid TransactionId { get; init; }
    public Guid ProductId { get; init; }
    public ushort Amount { get; init; }
    public Guid TopicId { get; init; }



    public override bool IsValid()
    {
        ValidationResult = new RegisterTransactionItemCommandValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}