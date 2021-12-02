using Stoqui.Kernel.Domain.Objects;

namespace Stoqui.Stock.Domain.Entities;

public class Transaction : Entity, IAggregateRoot
{

    private readonly List<TransactionItem> _transactionItems;

    public Transaction(string description, string stockist, string requester)
    {
        _transactionItems = new();

        Description = description;
        Stockist = stockist;
        Requester = requester;

        Validate();
    }

    private Transaction()
    {}
    

    public string Description { get; private set; }    
    public string Stockist { get; private set; }
    public string Requester { get; private set; }

    public IReadOnlyCollection<TransactionItem> TransactionItems => _transactionItems;


    protected sealed override void Validate()
    {
        AssertionConcern.NotEmpty(Description, "Description is required");
        AssertionConcern.NotEmpty(Stockist, "Stockist is required");
        AssertionConcern.NotEmpty(Requester, "Requester is required");

    }

}

