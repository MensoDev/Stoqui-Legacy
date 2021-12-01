using MediatR;
using Stoqui.Kernel.Domain.Communication.Mediator;
using Stoqui.Kernel.Domain.Extensions;
using Stoqui.Stock.Application.Commands;
using Stoqui.Stock.Application.Interfaces.Repositories;
using Stoqui.Stock.Domain.Entities;

namespace Stoqui.Stock.Application.CommandHandlers;

public class ProductCommandHandler :
    IRequestHandler<RegisterProductCommand, bool>

{
    private readonly IProductRepository _productRepository;
    private readonly IMediatorHandler _mediatorHandler;

    public ProductCommandHandler(IProductRepository productRepository, IMediatorHandler mediatorHandler)
    {
        _productRepository = productRepository;
        _mediatorHandler = mediatorHandler;
    }

    public async Task<bool> Handle(RegisterProductCommand request, CancellationToken cancellationToken)
    {
        if (!await _mediatorHandler.ValidateCommandAsync(request)) return await Task.FromResult(false);

        var product = new Product(request.Id, request.Name);

        //TODO: Register Events Here
        //product.AddEvent();

        await _productRepository.AddAsync(product);
        return await _productRepository.UnitOfWork.CommitAsync();
    }
}