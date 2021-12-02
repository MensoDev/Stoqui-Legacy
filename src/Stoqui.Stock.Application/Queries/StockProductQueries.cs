using AutoMapper;
using Stoqui.Kernel.Domain.Objects;
using Stoqui.Stock.Application.Interfaces.Models;
using Stoqui.Stock.Application.Interfaces.Queries;
using Stoqui.Stock.Application.Interfaces.Repositories;
using Stoqui.Stock.Domain.Entities;

namespace Stoqui.Stock.Application.Queries;

public class StockProductQueries : IStockProductQueries
{

    private  readonly IProductRepository _productRepository;
    private  readonly IMapper _mapper;

    public StockProductQueries(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<PagingResult<ProductStockModel>> PaginationAsync(Paging<Product> paging)
    {
        var pagingResult = await _productRepository.PaginationAsync(paging);
        return _mapper.Map<PagingResult<ProductStockModel>>(pagingResult);
    }
}