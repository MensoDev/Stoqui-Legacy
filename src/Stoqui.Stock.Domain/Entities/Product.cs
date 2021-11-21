using Stoqui.Kernel.Domain.Objects;

namespace Stoqui.Stock.Domain.Entities;

public class Product : Entity, IAggregateRoot
{

    private List<Transaction> _transactions;

    public Product(Guid productId)
    {
        Id = productId;
        _transactions = new();

        ActiveStock = 0;
        RepairStock = 0;
        TrashStock = 0;

        Validate();
    }


    public int ActiveStock { get; private set; }
    public int RepairStock { get; private set; }
    public int TrashStock { get; private set; }
    public IReadOnlyCollection<Transaction> Transactions => _transactions;

    protected override void Validate()
    {
        AssertionConcern.NotEmpty(Id, "Product.Id is required");
    }


}

