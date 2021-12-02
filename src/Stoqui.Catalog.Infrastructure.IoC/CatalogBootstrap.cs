using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Stoqui.Catalog.Application.Interfaces.Repositories;
using Stoqui.Catalog.Application.Interfaces.Services;
using Stoqui.Catalog.Application.Profiles;
using Stoqui.Catalog.Application.Services;
using Stoqui.Catalog.Infrastructure.DataAccess;
using Stoqui.Catalog.Infrastructure.DataAccess.Repositories;

namespace Stoqui.Catalog.Infrastructure.IoC;

public static class CatalogBootstrap
{
    public static void AddCatalogConfigure(this IServiceCollection service, string connectionString)
    {
        service.AddDbContext<CatalogDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        service.AddScoped<IProductAppService, ProductAppService>();
        service.AddScoped<IProductRepository, ProductRepository>();
        
        service.AddAutoMapper(options =>
        {
            options.AddProfile<RegisterProductModelProfile>();
        });

    }
}