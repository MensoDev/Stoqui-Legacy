using System.Linq.Expressions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Stoqui.Kernel.Domain.Communication.Mediator;
using Stoqui.Kernel.Domain.Messages.Notifications;
using Stoqui.Kernel.Domain.Objects;
using Stoqui.Models;
using Stoqui.Models.Stock;
using Stoqui.Stock.Application.Commands;
using Stoqui.Stock.Application.Interfaces.Models;
using Stoqui.Stock.Application.Interfaces.Queries;
using Stoqui.Stock.Domain.Entities;
using Stoqui.Stock.Domain.Enums;

namespace Stoqui.Web.RestApi.Controllers;

[Route("[controller]")]
[ApiController]
public class StockTopicsController : StoquiControllerBase
{
    private readonly ILogger<StockTopicsController> _logger;
    private readonly ITransactionTopicQueries _transactionTopicQueries;

    public StockTopicsController(
        INotificationHandler<DomainNotification> notifications,
        IMediatorHandler mediatorHandler,
        ILogger<StockTopicsController> logger, 
        ITransactionTopicQueries transactionTopicQueries) : base(notifications, mediatorHandler)
    {
        _logger = logger;
        _transactionTopicQueries = transactionTopicQueries;
    }

    [HttpPost]
    public async Task<ActionResult<ApiResult>> RegisterTransactionTopicAsync
        ([FromBody] RegisterTopicCommandViewModel model)
    {
        try
        {
            var (name, eStockTypeViewModel, eStockActionViewModel) = model;
                
            var stockType = Enum.Parse<EStockType>(eStockTypeViewModel.ToString());
            var stockAction = Enum.Parse<EStockAction>(eStockActionViewModel.ToString());

            var command = new RegisterTransactionTopicCommand(name, stockType, stockAction);
            var success = await _mediatorHandler.SendCommandAsync(command);

            if (success) return Ok(new ApiResult("Success", success));

            return BadRequest(
                new ApiResult(
                    "RegisterTransactionTopicAsync",
                    false,
                    GetNotification()));
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error on RegisterTransactionTopicAsync");
            return BadRequest(new ApiResult("Error on Register Transaction Topic", false));
        }
    }

    [HttpGet]
    public async Task<ActionResult<PagingResult<TransactionTopicModel>>> TopicPagination
        ([FromQuery] PagingViewModel model)
    {
        var pagingQuery = new Paging<TransactionTopic>(
            model.PageNumber,
            (ushort)model.PageSize,
            CreateFilterExpression(model.Filter),
            CreateOrderByFunction(model.OrderByPropertyName));

        var pagingResult = await _transactionTopicQueries.PaginationAsync(pagingQuery);

        return Ok(pagingResult);
    }
    
    private static Expression<Func<TransactionTopic, bool>>? CreateFilterExpression(string? filter)
    {
        if (filter != null)
            return p => p.Name.Contains(filter);

        return null;
    }

    private static Func<IQueryable<TransactionTopic>, IOrderedQueryable<TransactionTopic>>? CreateOrderByFunction(string? property)
    {
        if (property == null) return p => p.OrderBy(o => o.Name);

        return property switch
        {
            "Name" => p => p.OrderBy(o => o.Name),
            "StockAction" => p => p.OrderBy(o => o.StockAction),
            "StockType" => p => p.OrderBy(o => o.StockType),
            _ => p => p.OrderBy(o => o.Name)
        };
    }
    
    
}