using Stoqui.Kernel.Domain.Objects;
using Stoqui.Stock.Application.Interfaces.Models;
using Stoqui.Stock.Domain.Entities;

namespace Stoqui.Stock.Application.Interfaces.Queries;

public interface ITransactionTopicQueries
{
    Task<PagingResult<TransactionTopicModel>> PaginationAsync(Paging<TransactionTopic> paging);
}