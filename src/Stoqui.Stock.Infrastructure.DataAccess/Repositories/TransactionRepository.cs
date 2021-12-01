using Microsoft.EntityFrameworkCore;
using Stoqui.Stock.Application.Interfaces.Repositories;
using Stoqui.Stock.Domain.Entities;

namespace Stoqui.Stock.Infrastructure.DataAccess.Repositories;

public class TransactionRepository : RepositoryBase<Transaction>, ITransactionRepository
{

    private  readonly DbSet<TransactionItem> _transactionItems;

    public TransactionRepository(StockDbContext dbContext) : base(dbContext)
    {
        _transactionItems = dbContext.TransactionItems;
    }

    public async ValueTask AddTransactionItemAsync(TransactionItem item)
    {
        await _transactionItems.AddAsync(item);
    }

    public async ValueTask<TransactionItem?> GetTransactionItemByIdAsync(Guid transactionItemId)
    {
        return await _transactionItems.FindAsync(transactionItemId);
    }

    public async ValueTask<IEnumerable<TransactionItem>> GetTransactionItemsByTransactionIdAsync(Guid transactionId)
    {
        return await _transactionItems
            .AsNoTracking()
            .Include(p => p.Product)
            .Include(p => p.Topic)
            .Where(p => p.TransactionId == transactionId)
            .ToListAsync();
    }

    public void UpdateTransactionItem(TransactionItem item)
    {
        _transactionItems.Update(item);
    }

    public void DeleteTransactionItem(TransactionItem item)
    {
        _transactionItems.Remove(item);
    }
}