using Flunt.Notifications;
using Stoqui.Kernel.Domain.Communication.Mediator;
using Stoqui.Kernel.Domain.Messages;
using Stoqui.Kernel.Domain.Messages.Notifications;

namespace Stoqui.Kernel.Domain.Extensions;

public static class MediatorHandlerCommandExtensions
{
    public static async Task<bool> ValidateCommandAsync(this IMediatorHandler mediatorHandler, Command command)
    {
        if (command.IsValid()) return await Task.FromResult(true);

        if (command.ValidationResult is null)
        {
            await mediatorHandler
                .PublishNotificationAsync("ValidationResult", "Null Reference Exception for ValidationResult");
            return await Task.FromResult(false);
        }

        foreach (var item in command.ValidationResult.Errors)
        {
            // Domain Notification Here
            await mediatorHandler.PublishNotificationAsync($"{command.MessageType} - {item.PropertyName}",
                item.ErrorMessage);
        }

        return await Task.FromResult(false);
    }

    public static async Task<bool> ValidateModelAsync(this IMediatorHandler mediatorHandler, Notifiable<Notification> notifiable)
    {
        if (notifiable.IsValid) return await Task.FromResult(true);

        foreach (var notification in notifiable.Notifications)
        {
            await mediatorHandler.PublishNotificationAsync(
                notification.Key,
                notification.Message);
        }

        return await Task.FromResult(false);
    }

    public static async Task PublishNotificationAsync(this IMediatorHandler mediatorHandler, string key, string message)
    {
        await mediatorHandler.PublishNotificationAsync(new DomainNotification(key, message));
    }
}