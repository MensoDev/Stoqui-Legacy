using System.Linq.Expressions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Stoqui.Kernel.Domain.Communication.Mediator;
using Stoqui.Kernel.Domain.Messages.Notifications;
using Stoqui.Kernel.Domain.Objects;
using Stoqui.Models;
using Stoqui.Stock.Application.Interfaces.Models;
using Stoqui.Stock.Application.Interfaces.Queries;
using Stoqui.Stock.Domain.Entities;

namespace Stoqui.Web.RestApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StockProductController : StoquiControllerBase
    {

        private readonly IStockProductQueries _productQueries;
        
        public StockProductController(
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediatorHandler, IStockProductQueries productQueries)
            : base(notifications, mediatorHandler)
        {
            _productQueries = productQueries;
        }

        [HttpGet]
        public async Task<ActionResult<PagingResult<ProductStockModel>>> GetProducts([FromQuery] PagingViewModel model)
        {
            var pagingQuery = new Paging<Product>(
                model.PageNumber,
                (ushort)model.PageSize,
                CreateFilterExpression(model.Filter),
                CreateOrderByFunction(model.OrderByPropertyName));

            var pagingResult = await _productQueries.PaginationAsync(pagingQuery);

            return Ok(pagingResult);
        }

        private static Expression<Func<Product, bool>>? CreateFilterExpression(string? filter)
        {
            if (filter != null)
                return p => p.Name.Contains(filter);

            return null;
        }

        private static Func<IQueryable<Product>, IOrderedQueryable<Product>>? CreateOrderByFunction(string? property)
        {
            if (property == null) return p => p.OrderBy(o => o.Name);

            return property.ToLower() switch
            {
                "name" => p => p.OrderBy(o => o.Name),
                _ => p => p.OrderBy(o => o.Name)
            };
        }
    }
}
