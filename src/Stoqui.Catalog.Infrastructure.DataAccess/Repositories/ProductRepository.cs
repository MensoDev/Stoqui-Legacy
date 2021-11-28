using Stoqui.Catalog.Application.Interfaces.Repositories;
using Stoqui.Catalog.Domain.Entities;

namespace Stoqui.Catalog.Infrastructure.DataAccess.Repositories;

public class ProductRepository : RepositoryBase<Product>, IProductRepository
{
    public ProductRepository(CatalogDbContext dbContext) : base(dbContext)
    {
    }
}

