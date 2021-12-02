using Microsoft.EntityFrameworkCore;
using Stoqui.Catalog.Domain.Entities;
using Stoqui.Catalog.Infrastructure.DataAccess.Configurations;
using Stoqui.Kernel.Domain.Communication.Mediator;
using Stoqui.Kernel.Domain.Data;
using Stoqui.Kernel.Domain.Messages;
using Stoqui.Kernel.Infrastructure.DataAccess.Extensions;

namespace Stoqui.Catalog.Infrastructure.DataAccess;

public class CatalogDbContext : DbContext, IUnitOfWork
{

    private  readonly IMediatorHandler _mediatorHandler;

    public CatalogDbContext(
        DbContextOptions<CatalogDbContext> options, 
        IMediatorHandler mediatorHandler) : base(options)
    {
        _mediatorHandler = mediatorHandler;
    }

    public DbSet<Product> Products { get; set; }

    #region Required
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<Event>();
        modelBuilder.ApplyConfiguration(new ProductConfigure());
    }
    #endregion

    public async Task<bool> CommitAsync()
    {
        foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("RegistrationDate") != null))
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property("RegistrationDate").CurrentValue = DateTime.Now;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Property("RegistrationDate").IsModified = false;
            }
        }

        var success = await base.SaveChangesAsync() > 0;
        if (success) await _mediatorHandler.PublishEvents(this);
        return success;
    }
}

