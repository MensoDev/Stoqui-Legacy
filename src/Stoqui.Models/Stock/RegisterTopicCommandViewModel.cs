using System.ComponentModel.DataAnnotations;

namespace Stoqui.Models.Stock;

public record RegisterTopicCommandViewModel
(
    [Required] string Name,
    [Required] EStockTypeViewModel StockType,
    [Required] EStockActionViewModel StockAction
);