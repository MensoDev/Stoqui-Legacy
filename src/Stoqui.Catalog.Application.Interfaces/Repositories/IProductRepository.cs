using Stoqui.Catalog.Domain.Entities;
using Stoqui.Kernel.Domain.Data;

namespace Stoqui.Catalog.Application.Interfaces.Repositories;

public interface IProductRepository : IRepository<Product>
{
    ValueTask AddProductAsync(Product product);
    ValueTask<Product> GetProductByIdAsync(Guid productId);

    void DeleteProduct(Product product);
    void UpdateProduct(Product product);
}

