using MediatR;
using Stoqui.Kernel.Domain.Communication.Mediator;
using Stoqui.Kernel.Domain.Extensions;
using Stoqui.Stock.Application.Commands;
using Stoqui.Stock.Application.Interfaces.Repositories;
using Stoqui.Stock.Domain.Entities;

namespace Stoqui.Stock.Application.CommandHandlers;

public class TransactionTopicCommandHandler :
    IRequestHandler<RegisterTransactionTopicCommand, bool>
{

    private  readonly  IMediatorHandler _mediatorHandler;
    private  readonly  ITransactionTopicRepository _transactionTopicRepository;

    public TransactionTopicCommandHandler(IMediatorHandler mediatorHandler, ITransactionTopicRepository transactionTopicRepository)
    {
        _mediatorHandler = mediatorHandler;
        _transactionTopicRepository = transactionTopicRepository;
    }

    public async Task<bool> Handle(RegisterTransactionTopicCommand request, CancellationToken cancellationToken)
    {
        if (await _mediatorHandler.ValidateCommandAsync(request)) return await Task.FromResult(false);

        var topic = new TransactionTopic(request.Name, request.StockType, request.StockAction);


        //TODO: Event Register in Entity
        //topic.AddEvent(event here);

        await _transactionTopicRepository.AddAsync(topic);
        return await _transactionTopicRepository.UnitOfWork.CommitAsync();
    }
}