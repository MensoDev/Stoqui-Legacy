using Stoqui.Kernel.Domain.Communication.Mediator;
using Stoqui.Kernel.Domain.Messages;
using Stoqui.Kernel.Domain.Messages.Notifications;

namespace TryFi.Kernel.Domain.Extensions
{
    public static class IMediatorHandlerCommandExtensions
    {
        public static async Task<bool> ValidateCommand(this IMediatorHandler mediatorHandler, Command command)
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

        public static async Task PublishNotificationAsync(this IMediatorHandler mediatorHandler, string key, string message)
        {
            await mediatorHandler.PublishNotificationAsync(new DomainNotification(key, message));
        }
    }
}
