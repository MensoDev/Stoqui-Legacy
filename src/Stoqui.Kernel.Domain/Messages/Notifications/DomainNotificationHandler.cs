using MediatR;

namespace Stoqui.Kernel.Domain.Messages.Notifications;

public class DomainNotificationHandler : INotificationHandler<DomainNotification>, IDisposable
{

    private List<DomainNotification> _notifications;

    public DomainNotificationHandler()
    {
        _notifications = new List<DomainNotification>();
    }

    public async Task Handle(DomainNotification notification, CancellationToken cancellationToken)
    {
        _notifications.Add(notification);
        await Task.CompletedTask;
    }

    public virtual List<DomainNotification> GetNotifications() =>  _notifications;
    

    public virtual bool HasNotification() => GetNotifications().Any();
    

    public void Dispose() => _notifications.Clear();
    

}

