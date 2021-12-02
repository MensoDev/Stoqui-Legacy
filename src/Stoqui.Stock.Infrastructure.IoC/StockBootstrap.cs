using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Stoqui.Kernel.Domain.Messages.IntegrationEvents;
using Stoqui.Stock.Application.CommandHandlers;
using Stoqui.Stock.Application.Commands;
using Stoqui.Stock.Application.EventHandlers;
using Stoqui.Stock.Application.Interfaces.Queries;
using Stoqui.Stock.Application.Interfaces.Repositories;
using Stoqui.Stock.Application.Queries;
using Stoqui.Stock.Application.Queries.MapperProfile;
using Stoqui.Stock.Infrastructure.DataAccess;
using Stoqui.Stock.Infrastructure.DataAccess.Repositories;

namespace Stoqui.Stock.Infrastructure.IoC;

public static class StockBootstrap 
{
    public static void AddStockConfigure(this IServiceCollection service, string connectionString)
    {
        service.AddDbContext<StockDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        //Commands ans Handler
        service.AddTransient<IRequestHandler<RegisterProductCommand, bool>, ProductCommandHandler>();

        service.AddTransient<IRequestHandler<RegisterTransactionTopicCommand, bool>, TransactionTopicCommandHandler>();

        service.AddTransient<IRequestHandler<RegisterTransactionCommand, bool>, TransactionCommandHandler>();
        service.AddTransient<IRequestHandler<RegisterTransactionItemCommand, bool>, TransactionCommandHandler>();

        //Queries
        service.AddTransient<IStockProductQueries, StockProductQueries>();

        //Events
        service.AddScoped<INotificationHandler<SuccessfullyRegisteredProductEvent>, ProductEventHandler>();

        //Repositories
        service.AddScoped<IProductRepository, ProductRepository>();
        service.AddScoped<ITransactionTopicRepository, TransactionTopicRepository>();
        service.AddScoped<ITransactionRepository, TransactionRepository>();

        service.AddAutoMapper(options =>
        {
            options.AddProfile<ProductStockProfile>();
        });
    }
}