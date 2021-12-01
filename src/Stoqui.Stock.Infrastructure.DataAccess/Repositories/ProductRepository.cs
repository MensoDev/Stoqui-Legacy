using Stoqui.Stock.Application.Interfaces.Repositories;
using Stoqui.Stock.Domain.Entities;

namespace Stoqui.Stock.Infrastructure.DataAccess.Repositories;

public class ProductRepository : RepositoryBase<Product>, IProductRepository
{
    public ProductRepository(StockDbContext dbContext) : base(dbContext)
    {
    }
}