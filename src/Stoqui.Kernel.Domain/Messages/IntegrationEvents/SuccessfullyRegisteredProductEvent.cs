namespace Stoqui.Kernel.Domain.Messages.IntegrationEvents;

public class SuccessfullyRegisteredProductEvent : IntegrationEvent
{
    public SuccessfullyRegisteredProductEvent(Guid productId, string productName) 
        : base(productId)
    {
        ProductId = productId;
        ProductName = productName;
    }

    public Guid ProductId { get; private set; }
    public string ProductName { get; private set; }

}