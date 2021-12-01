using Stoqui.Stock.Application.Interfaces.Repositories;
using Stoqui.Stock.Domain.Entities;

namespace Stoqui.Stock.Infrastructure.DataAccess.Repositories;

public class TransactionTopicRepository : RepositoryBase<TransactionTopic>, ITransactionTopicRepository
{
    public TransactionTopicRepository(StockDbContext dbContext) : base(dbContext)
    {
    }
}