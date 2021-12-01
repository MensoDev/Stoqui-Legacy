using MediatR;
using Stoqui.Kernel.Domain.Communication.Mediator;
using Stoqui.Kernel.Domain.Extensions;
using Stoqui.Stock.Application.Commands;
using Stoqui.Stock.Application.Interfaces.Repositories;
using Stoqui.Stock.Domain.Entities;

namespace Stoqui.Stock.Application.CommandHandlers;

public class TransactionCommandHandler :
    IRequestHandler<RegisterTransactionCommand, bool>,
    IRequestHandler<RegisterTransactionItemCommand, bool>
{

    private readonly IMediatorHandler _mediatorHandler;
    private  readonly ITransactionRepository _transactionRepository;
    private readonly IProductRepository _productRepository;
    private  readonly ITransactionTopicRepository _transactionTopicRepository;

    public TransactionCommandHandler(
        IMediatorHandler mediatorHandler, 
        ITransactionRepository transactionRepository, 
        IProductRepository productRepository, 
        ITransactionTopicRepository transactionTopicRepository)
    {
        _mediatorHandler = mediatorHandler;
        _transactionRepository = transactionRepository;
        _productRepository = productRepository;
        _transactionTopicRepository = transactionTopicRepository;
    }


    public async Task<bool> Handle(RegisterTransactionCommand request, CancellationToken cancellationToken)
    {
        if (await _mediatorHandler.ValidateCommandAsync(request)) return await Task.FromResult(false);

        var transaction = new Transaction(request.Description, request.Stockist, request.Requester);

        //TODO: Register Events in Transaction Entity
        //transaction.AddEvent();

        await _transactionRepository.AddAsync(transaction);
        return await _transactionRepository.UnitOfWork.CommitAsync();
    }

    public async Task<bool> Handle(RegisterTransactionItemCommand request, CancellationToken cancellationToken)
    {
        if (await _mediatorHandler.ValidateCommandAsync(request)) return await Task.FromResult(false);

        var product = await _productRepository.GetByIdAsync(request.ProductId);

        if (product == null)
        {
            await _mediatorHandler.PublishNotificationAsync("RegisterTransactionItemCommand.ProductId", 
                "Product not exist");
            return false;
        }

        var transaction = await _transactionRepository.GetByIdAsync(request.TransactionId);

        if (transaction == null)
        {
            await _mediatorHandler.PublishNotificationAsync("RegisterTransactionItemCommand.TransactionId",
                "Transaction not exist");
            return false;
        }

        var topic = await _transactionTopicRepository.GetByIdAsync(request.TopicId);

        if (topic == null)
        {
            await _mediatorHandler.PublishNotificationAsync("RegisterTransactionItemCommand.TransactionTopicId",
                "Transaction Topic not exist");
            return false;
        }

        var transactionItem = new TransactionItem(product, transaction, request.Amount, topic);

        await _transactionRepository.AddTransactionItemAsync(transactionItem);
        return await _transactionRepository.UnitOfWork.CommitAsync();
    }
}