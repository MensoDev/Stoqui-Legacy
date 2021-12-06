using Stoqui.Kernel.Domain.Objects;
using Stoqui.Stock.Application.Interfaces.Models;
using Stoqui.Stock.Application.Interfaces.Queries;
using Stoqui.Stock.Domain.Entities;
using AutoMapper;
using Stoqui.Stock.Application.Interfaces.Repositories;

namespace Stoqui.Stock.Application.Queries;

public class TransactionTopicQueries : ITransactionTopicQueries
{
    
    private  readonly IMapper _mapper;
    private readonly ITransactionTopicRepository _transactionTopicRepository;


    public TransactionTopicQueries(IMapper mapper, ITransactionTopicRepository transactionTopicRepository)
    {
        _mapper = mapper;
        _transactionTopicRepository = transactionTopicRepository;
    }

    public async Task<PagingResult<TransactionTopicModel>> PaginationAsync(Paging<TransactionTopic> paging)
    {
        var paginationResult = await _transactionTopicRepository.PaginationAsync(paging);
        return _mapper.Map<PagingResult<TransactionTopicModel>>(paginationResult);
    }
}