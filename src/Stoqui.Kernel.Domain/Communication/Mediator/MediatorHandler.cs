using MediatR;
using Stoqui.Kernel.Domain.Messages;
using Stoqui.Kernel.Domain.Messages.DomainEvents;
using Stoqui.Kernel.Domain.Messages.Notifications;

namespace Stoqui.Kernel.Domain.Communication.Mediator;

public class MediatorHandler : IMediatorHandler
{

    private readonly IMediator _mediator;

    public MediatorHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task PublishDomainEventAsync<T>(T eventArgs) where T : DomainEvent
    {
        await _mediator.Publish(eventArgs);
    }

    public async Task PublishEventAsync<T>(T eventArgs) where T : Event
    {
        await _mediator.Publish(eventArgs);
    }

    public async Task PublishNotificationAsync<T>(T notification) where T : DomainNotification
    {
        await _mediator.Publish(notification);
    }

    public async Task<bool> SendCommandAsync<T>(T command) where T : Command
    {
        return await _mediator.Send(command);
    }
}

