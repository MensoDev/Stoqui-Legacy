using Stoqui.Kernel.Domain.Objects;

namespace Stoqui.Stock.Domain.Entities;

public class Transaction : Entity, IAggregateRoot
{
    public Transaction(string description, Product product, int amount, string stockist, string requester)
    {
        AssertionConcern.NotNull(product, "Product is Required");

        Description = description;
        Product = product;
        ProductId = product.Id;
        Amount = amount;
        Stockist = stockist;
        Requester = requester;

        Validate();
    }

    public string Description { get; private set; }
    public Product Product { get; private set; }
    public Guid ProductId { get; private set; }
    public int Amount { get; private set; }
    public string Stockist { get; private set; }
    public string Requester { get; private set; }


    protected override void Validate()
    {
        AssertionConcern.NotEmpty(ProductId, "Product.Id is required");
        AssertionConcern.NotEmpty(Description, "Description is required");
        AssertionConcern.NotEmpty(Stockist, "Stockist is required");
        AssertionConcern.NotEmpty(Requester, "Requester is required");

        AssertionConcern.GreaterThan(Amount, 0, "Transaction.Amount has to be bigger than 0");
    }

}

