using MediatR;
using Stoqui.Kernel.Domain.Communication.Mediator;
using Stoqui.Kernel.Domain.Messages.IntegrationEvents;
using Stoqui.Stock.Application.Commands;

namespace Stoqui.Stock.Application.EventHandlers;

public class ProductEventHandler :
    INotificationHandler<SuccessfullyRegisteredProductEvent>
{

    private readonly IMediatorHandler _mediatorHandler;

    public ProductEventHandler(IMediatorHandler mediatorHandler)
    {
        _mediatorHandler = mediatorHandler;
    }

    public async Task Handle(SuccessfullyRegisteredProductEvent notification, CancellationToken cancellationToken)
    {
        await _mediatorHandler.SendCommandAsync(
            new RegisterProductCommand(notification.ProductId, notification.ProductName));
    }
}