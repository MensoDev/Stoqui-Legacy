using Stoqui.Kernel.Domain.Data;
using Stoqui.Stock.Domain.Entities;

namespace Stoqui.Stock.Application.Interfaces.Repositories;

public interface ITransactionRepository : IRepository<Transaction>
{

    //Setters
    ValueTask AddTransactionItemAsync(TransactionItem item);

    //Getters
    ValueTask<TransactionItem> GetTransactionItemByIdAsync(Guid transactionItemId);
    ValueTask<TransactionItem> GetTransactionItemByTransactionIdAsync(Guid transactionId);

    //Updates
    void UpdateTransactionItem(TransactionItem item);

    //Deletes
    void DeleteTransactionItem(TransactionItem item);
}