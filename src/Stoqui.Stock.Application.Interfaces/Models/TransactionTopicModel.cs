using Stoqui.Stock.Domain.Enums;

namespace Stoqui.Stock.Application.Interfaces.Models;

public record TransactionTopicModel(
    string Name,
    EStockType StockType,
    EStockAction StockAction);