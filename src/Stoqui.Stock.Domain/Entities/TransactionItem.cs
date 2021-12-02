using Stoqui.Kernel.Domain.Objects;

namespace Stoqui.Stock.Domain.Entities;

public class TransactionItem : Entity
{
    public TransactionItem(Product product, Transaction transaction, ushort amount, TransactionTopic topic)
    {
        AssertionConcern.NotNull(product, "Product is Required");
        AssertionConcern.NotNull(transaction, "Transaction is Required");
        AssertionConcern.NotNull(topic, "Transaction Topic is required");

        Product = product;
        ProductId = product.Id;

        Transaction = transaction;
        TransactionId = transaction.Id;

        Amount = amount;
        Topic = topic;
        TopicId = topic.Id;

        Validate();
    }

    private TransactionItem()
    {}
    

    public Transaction Transaction { get; private set; }
    public Guid TransactionId { get; private set; }

    public Product Product { get; private set; }
    public Guid ProductId { get; private set; } 

    public ushort Amount { get; private set; }

    public TransactionTopic Topic { get; private set; }
    public Guid TopicId { get; private set; }


    protected sealed override void Validate()
    {
        AssertionConcern.GreaterThan(Amount, 0, "TransactionItem.Amount has to be bigger than 0");

        AssertionConcern.NotEmpty(ProductId, "ProductId is required");
        AssertionConcern.NotEmpty(TransactionId, "TransactionId is required");
        AssertionConcern.NotNull(TopicId, "TopicId is required");
    }
}

