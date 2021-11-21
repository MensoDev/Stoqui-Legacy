using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stoqui.Catalog.Domain.Entities;

namespace Stoqui.Catalog.Infrastructure.DataAccess.Configurations
{
    public class ProductConfigure : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(160);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(300);
        }
    }
}
