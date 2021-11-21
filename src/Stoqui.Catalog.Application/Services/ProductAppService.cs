using AutoMapper;
using Stoqui.Catalog.Application.Interfaces.Models;
using Stoqui.Catalog.Application.Interfaces.Repositories;
using Stoqui.Catalog.Application.Interfaces.Services;
using Stoqui.Catalog.Domain.Entities;

namespace Stoqui.Catalog.Application.Services;

public class ProductAppService : IProductAppService
{

    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public ProductAppService(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async ValueTask<bool> RegisterProductAsync(ProductModel model)
    {
        model.Validate();
        if (!model.IsValid) 
        {
            //TODO: Register Notifications
            return false;
        }

        var product = new Product(model.Name, model.Description);

        //TODO: Show Events Here

        await _productRepository.AddProductAsync(product);
        return await _productRepository.UnitOfWork.CommitAsync();
    }

    public void Dispose()
    {        
        GC.SuppressFinalize(this);
    }
}

