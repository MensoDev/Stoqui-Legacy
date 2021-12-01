﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Stoqui.Stock.Application.CommandHandlers;
using Stoqui.Stock.Application.Commands;
using Stoqui.Stock.Application.Interfaces.Repositories;
using Stoqui.Stock.Infrastructure.DataAccess;
using Stoqui.Stock.Infrastructure.DataAccess.Repositories;

namespace Stoqui.Stock.Infrastructure.IoC;

public static class StockBootstrap 
{
    public static void StockConfigure(this IServiceCollection service, string connectionString)
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


        //Repositories
        service.AddScoped<IProductRepository, ProductRepository>();
        service.AddScoped<ITransactionTopicRepository, TransactionTopicRepository>();
        service.AddScoped<ITransactionRepository, TransactionRepository>();
    }
}