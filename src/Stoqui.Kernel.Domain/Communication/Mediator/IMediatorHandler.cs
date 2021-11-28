using Stoqui.Kernel.Domain.Messages;
using Stoqui.Kernel.Domain.Messages.DomainEvents;
using Stoqui.Kernel.Domain.Messages.Notifications;

namespace Stoqui.Kernel.Domain.Communication.Mediator;

public interface IMediatorHandler
{

    Task<bool> SendCommandAsync<T>(T command) where T : Command;
    Task PublishEventAsync<T>(T eventArgs) where T : Event;
    Task PublishDomainEventAsync<T>(T eventArgs) where T : DomainEvent;

    Task PublishNotificationAsync<T>(T notification) where T : DomainNotification;

}

