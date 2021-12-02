using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Stoqui.Kernel.Domain.Communication.Mediator;
using Stoqui.Kernel.Domain.Messages.Notifications;

namespace Stoqui.Kernel.Infrastructure.IoC;

public static class KernelBootstrap
{
    public static void AddKernelConfigure(this IServiceCollection services, Type type)
    {
        services.AddMediatR(type);
        services.AddScoped<IMediatorHandler, MediatorHandler>();

        // Notifications
        services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
    }
}