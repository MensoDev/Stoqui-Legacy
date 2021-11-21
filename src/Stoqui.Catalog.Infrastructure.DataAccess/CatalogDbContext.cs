using Microsoft.EntityFrameworkCore;
using Stoqui.Catalog.Domain.Entities;
using Stoqui.Catalog.Infrastructure.DataAccess.Configurations;
using Stoqui.Kernel.Domain.Data;

namespace Stoqui.Catalog.Infrastructure.DataAccess;

public class CatalogDbContext : DbContext, IUnitOfWork
{

    public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options)
    {}

    public DbSet<Product> Products { get; set; }

    #region Required
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductConfigure());
    }
    #endregion

    public Task<bool> CommitAsync()
    {
        throw new NotImplementedException();
    }
}

