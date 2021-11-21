using Microsoft.EntityFrameworkCore;
using Stoqui.Catalog.Application.Interfaces.Repositories;
using Stoqui.Catalog.Domain.Entities;

namespace Stoqui.Catalog.Infrastructure.DataAccess.Repositories;

public class ProductRepository : RepositoryBase<Product>, IProductRepository
{

    private readonly DbSet<Product> _products;

    public ProductRepository(CatalogDbContext dbContext) : base(dbContext)
    {
        _products = dbContext.Products;
    }

    public async ValueTask AddProductAsync(Product product)
    {
        await _products.AddAsync(product);
    }

    public void DeleteProduct(Product product)
    {
        _products.Remove(product);
    }

    public async ValueTask<Product> GetProductByIdAsync(Guid productId) => 
        await _products.FindAsync(productId);

    public void UpdateProduct(Product product)
    {
        _products.Update(product);
    }
}

