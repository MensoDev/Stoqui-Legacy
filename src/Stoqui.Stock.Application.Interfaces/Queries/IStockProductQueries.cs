using Stoqui.Kernel.Domain.Objects;
using Stoqui.Stock.Application.Interfaces.Models;
using Stoqui.Stock.Domain.Entities;

namespace Stoqui.Stock.Application.Interfaces.Queries;

public interface IStockProductQueries
{
    Task<PagingResult<ProductStockModel>> PaginationAsync(Paging<Product> paging);
}