using Stoqui.Kernel.Domain.Objects;

namespace Stoqui.Stock.Domain.Entities;

public class Product : Entity, IAggregateRoot
{

    private List<TransactionItem> _transactionItems = new();

    public Product(Guid productId, string name)
    {
        Name = name;
        Id = productId;

        ActiveStock = 0;
        RepairStock = 0;
        TrashStock = 0;

        Validate();
    }
    
    protected Product()
    {}

    public string Name { get; private set; }

    public int ActiveStock { get; private set; }
    public int RepairStock { get; private set; }
    public int TrashStock { get; private set; }


    public IReadOnlyCollection<TransactionItem> TransactionItems => _transactionItems;

    protected sealed override void Validate()
    {
        AssertionConcern.NotEmpty(Id, "Product.Id is required");
        AssertionConcern.NotEmpty(Name, "Product Name is required");
    }


}

