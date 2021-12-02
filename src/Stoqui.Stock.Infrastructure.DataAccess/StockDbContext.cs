using Microsoft.EntityFrameworkCore;
using Stoqui.Kernel.Domain.Communication.Mediator;
using Stoqui.Kernel.Domain.Data;
using Stoqui.Kernel.Domain.Messages;
using Stoqui.Kernel.Infrastructure.DataAccess.Extensions;
using Stoqui.Stock.Domain.Entities;

namespace Stoqui.Stock.Infrastructure.DataAccess;

public class StockDbContext : DbContext, IUnitOfWork
{
    private readonly IMediatorHandler _mediatorHandler;

    public StockDbContext(
        DbContextOptions<StockDbContext> options, 
        IMediatorHandler mediatorHandler) : base(options)
    {
        _mediatorHandler = mediatorHandler;
    }

    public DbSet<Product> Products { get;  set; }
    public DbSet<TransactionTopic> TransactionTopics { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<TransactionItem> TransactionItems { get; set; }


    #region Required
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<Event>();
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(StockDbContext).Assembly);
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