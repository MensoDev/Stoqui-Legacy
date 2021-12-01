using Microsoft.EntityFrameworkCore;
using Stoqui.Kernel.Domain.Data;
using Stoqui.Stock.Domain.Entities;

namespace Stoqui.Stock.Infrastructure.DataAccess;

public class StockDbContext : DbContext, IUnitOfWork
{
    public StockDbContext(DbContextOptions<StockDbContext> options) : base(options)
    {}

    public DbSet<Product> Products { get;  set; }
    public DbSet<TransactionTopic> TransactionTopics { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<TransactionItem> TransactionItems { get; set; }


    #region Required
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(StockDbContext).Assembly);
    }
    #endregion

    public Task<bool> CommitAsync()
    {
        throw new NotImplementedException();
    }
}