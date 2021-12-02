using AutoMapper;
using Stoqui.Catalog.Application.Interfaces.Models;
using Stoqui.Catalog.Application.Interfaces.Repositories;
using Stoqui.Catalog.Application.Interfaces.Services;
using Stoqui.Catalog.Domain.Entities;
using Stoqui.Kernel.Domain.Communication.Mediator;
using Stoqui.Kernel.Domain.Extensions;
using Stoqui.Kernel.Domain.Messages.IntegrationEvents;

namespace Stoqui.Catalog.Application.Services;

public class ProductAppService : IProductAppService
{

    private readonly IMapper _mapper;
    private readonly IMediatorHandler _mediatorHandler;
    private readonly IProductRepository _productRepository;

    public ProductAppService(IMapper mapper, IProductRepository productRepository, IMediatorHandler mediatorHandler)
    {
        _mapper = mapper;
        _productRepository = productRepository;
        _mediatorHandler = mediatorHandler;
    }

    public async ValueTask<bool> RegisterProductAsync(RegisterProductModel model)
    {
        await _mediatorHandler.ValidateModelAsync(model);

        var product = new Product(model.Name, model.Description);
        
        //Events
        product.AddEvent(new SuccessfullyRegisteredProductEvent(product.Id, product.Name));

        await _productRepository.AddAsync(product);
        return await _productRepository.UnitOfWork.CommitAsync();
    }

    public void Dispose()
    {        
        GC.SuppressFinalize(this);
    }
}

