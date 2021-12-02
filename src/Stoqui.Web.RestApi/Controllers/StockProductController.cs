using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stoqui.Kernel.Domain.Communication.Mediator;
using Stoqui.Kernel.Domain.Messages.Notifications;
using Stoqui.Kernel.Domain.Objects;
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

        [HttpGet("{page}/{pageSize}")]
        public async Task<ActionResult<PagingResult<ProductStockModel>>> GetProducts([FromRoute]ushort page, [FromRoute]ushort pageSize)
        {
            var pagingQuery = new Paging<Product>(page, pageSize);
            var pagingResult = await _productQueries.PaginationAsync(pagingQuery);

            return Ok(pagingResult);
        }
    }
}
