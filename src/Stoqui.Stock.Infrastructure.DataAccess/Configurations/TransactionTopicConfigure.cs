using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stoqui.Stock.Domain.Entities;

namespace Stoqui.Stock.Infrastructure.DataAccess.Configurations;

public class TransactionTopicConfigure : IEntityTypeConfiguration<TransactionTopic>
{
    public void Configure(EntityTypeBuilder<TransactionTopic> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .HasMaxLength(250)
            .IsRequired();
    }
}