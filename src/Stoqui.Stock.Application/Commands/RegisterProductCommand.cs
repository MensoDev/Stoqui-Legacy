using Stoqui.Kernel.Domain.Messages;
using Stoqui.Stock.Application.Validations;

namespace Stoqui.Stock.Application.Commands;

public class RegisterProductCommand : Command
{

    public RegisterProductCommand(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; init; }
    public string Name { get; init; }

    public override bool IsValid()
    {
        ValidationResult = new RegisterProductCommandValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}