using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stoqui.Stock.Domain.Entities;

namespace Stoqui.Stock.Infrastructure.DataAccess.Configurations;

internal class TransactionConfigure : 
    IEntityTypeConfiguration<Transaction>,
    IEntityTypeConfiguration<TransactionItem>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Description)
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(p => p.Requester)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(p => p.Stockist)
            .HasMaxLength(150)
            .IsRequired();

        builder.HasMany(p => p.TransactionItems)
            .WithOne(p => p.Transaction)
            .HasForeignKey(p => p.TransactionId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    public void Configure(EntityTypeBuilder<TransactionItem> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.ProductId).IsRequired();
        builder.Property(p => p.TransactionId).IsRequired();
        builder.Property(p => p.TopicId).IsRequired();

        builder.HasOne(p => p.Product)
            .WithMany(p => p.TransactionItems)
            .HasForeignKey(p => p.ProductId);

        builder.HasOne(p => p.Transaction)
            .WithMany(p => p.TransactionItems)
            .HasForeignKey(p => p.TransactionId);

        builder.HasOne(p => p.Topic)
            .WithMany();
    }
}