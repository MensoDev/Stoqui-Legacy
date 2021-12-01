using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Stoqui.Kernel.Infrastructure.IoC;

public static class KernelBootstrap
{
    public static void KernelConfigure(this IServiceCollection service, Type type)
    {
        service.AddMediatR(type);
    }
}