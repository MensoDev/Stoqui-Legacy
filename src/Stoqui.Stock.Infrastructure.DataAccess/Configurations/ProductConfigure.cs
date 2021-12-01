using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stoqui.Stock.Domain.Entities;

namespace Stoqui.Stock.Infrastructure.DataAccess.Configurations;

public class ProductConfigure : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name).HasMaxLength(250).IsRequired();
        builder
            .HasMany(p => p.TransactionItems)
            .WithOne(p => p.Product)
            .HasForeignKey(p => p.ProductId);

        builder.Property(p => p.ActiveStock).IsRequired();
        builder.Property(p => p.TrashStock).IsRequired();
        builder.Property(p => p.RepairStock).IsRequired();
    }
}