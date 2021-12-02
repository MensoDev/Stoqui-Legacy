using MediatR;
using Microsoft.AspNetCore.Mvc;
using Stoqui.Kernel.Domain.Communication.Mediator;
using Stoqui.Kernel.Domain.Messages.Notifications;

namespace Stoqui.Web.RestApi.Controllers;


public abstract class StoquiControllerBase : ControllerBase
{
    protected readonly DomainNotificationHandler _notifications;
    protected readonly IMediatorHandler _mediatorHandler;

    protected Guid UserId = Guid.Parse("4885e451-b0e4-4490-b959-04fabc806d32");

    protected StoquiControllerBase(
        INotificationHandler<DomainNotification> notifications, 
    IMediatorHandler mediatorHandler)
    {
        _notifications = (DomainNotificationHandler)notifications;
        _mediatorHandler = mediatorHandler;
    }

    protected bool HasNotification()
    {
        return _notifications.HasNotification();
    }

    protected IEnumerable<string> GetNotification()
    {
        return _notifications.GetNotifications().Select(c => c.Value).ToList();
    }

    protected async Task AddNotification(string key, string message)
    {
        await _mediatorHandler.PublishNotificationAsync(new DomainNotification(key, message));
    }
}