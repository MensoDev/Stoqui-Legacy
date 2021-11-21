using Stoqui.Kernel.Domain.Objects;
using Stoqui.Stock.Domain.Enums;

namespace Stoqui.Stock.Domain.Entities;

public class TransactionTopic : Entity
{

    public TransactionTopic(string name, EStockType stockType, EStockAction stockAction)
    {
        Name = name;
        StockType = stockType;
        StockAction = stockAction;

        Validate();
    }

    public string Name { get; private set; }
    public EStockType StockType { get; private set; }
    public EStockAction StockAction { get; private set; }


    protected override void Validate()
    {
        AssertionConcern.NotEmpty(Name, "Name is required");
    }
}

