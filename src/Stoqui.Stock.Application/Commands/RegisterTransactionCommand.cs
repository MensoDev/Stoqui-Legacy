using Stoqui.Kernel.Domain.Messages;
using Stoqui.Stock.Application.Validations;

namespace Stoqui.Stock.Application.Commands;

public class RegisterTransactionCommand : Command
{
    public RegisterTransactionCommand(string description, string stockist, string requester)
    {
        Description = description;
        Stockist = stockist;
        Requester = requester;
    }

    public string Description { get; private set; }
    public string Stockist { get; private set; }
    public string Requester { get; private set; }

    public override bool IsValid()
    {
        ValidationResult = new RegisterTransactionCommandValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}
