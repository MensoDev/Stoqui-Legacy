using Stoqui.Kernel.Domain.Messages;
using Stoqui.Stock.Application.Validations;
using Stoqui.Stock.Domain.Enums;

namespace Stoqui.Stock.Application.Commands;

public class RegisterTransactionTopicCommand : Command
{
    public RegisterTransactionTopicCommand(string name, EStockType stockType, EStockAction stockAction)
    {
        Name = name;
        StockType = stockType;
        StockAction = stockAction;
    }

    public string Name { get; private set; }
    public EStockType StockType { get; private set; }
    public EStockAction StockAction { get; private set; }

    public override bool IsValid()
    {
        ValidationResult = new RegisterTransactionTopicCommandValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}



