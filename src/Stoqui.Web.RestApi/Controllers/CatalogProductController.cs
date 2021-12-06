using MediatR;
using Microsoft.AspNetCore.Mvc;
using Stoqui.Catalog.Application.Interfaces.Models;
using Stoqui.Catalog.Application.Interfaces.Services;
using Stoqui.Kernel.Domain.Communication.Mediator;
using Stoqui.Kernel.Domain.Messages.Notifications;
using Stoqui.Models;
using Stoqui.Models.Catalog;

namespace Stoqui.Web.RestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogProductController : StoquiControllerBase
    {
        private readonly ILogger<CatalogProductController> _logger;
        private  readonly IProductAppService _productAppService;

        public CatalogProductController(
            ILogger<CatalogProductController> logger, 
            IProductAppService productAppService,
            INotificationHandler<DomainNotification> notifications, 
            IMediatorHandler mediatorHandler) 
            : base(notifications, mediatorHandler)
        {
            _logger = logger;
            _productAppService = productAppService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterProductAsync([FromBody] RegisterProductViewModel? model)
        {
            if (model == null)
            { 
                _logger.LogWarning("RegisterProductAsync: Bad request");
                return BadRequest(new ApiResult("Product not registered", false));
            }

            var registerProductModel = new RegisterProductModel(model.Name, model.Description);
            var success = await _productAppService.RegisterProductAsync(registerProductModel);

            if (HasNotification())
                return BadRequest(new ApiResult("Product not registered", success, GetNotification()));

            _logger.LogInformation("Registered a new product");
            return Ok(new ApiResult("Product Registered", success, new List<string>()));
        }
        

    }
}