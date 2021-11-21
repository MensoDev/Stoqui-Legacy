using Stoqui.Catalog.Application.Interfaces.Models;

namespace Stoqui.Catalog.Application.Interfaces.Services;

public interface IProductAppService : IDisposable
{
    ValueTask<bool> RegisterProductAsync(ProductModel model);
}

