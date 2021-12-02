using MediatR;
using Microsoft.AspNetCore.Mvc;
using Stoqui.Catalog.Application.Interfaces.Models;
using Stoqui.Catalog.Application.Interfaces.Services;
using Stoqui.Kernel.Domain.Communication.Mediator;
using Stoqui.Kernel.Domain.Messages.Notifications;
using Stoqui.Models;

namespace Stoqui.Web.RestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : StoquiControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private  readonly IProductAppService _productAppService;

        public ProductController(
            ILogger<ProductController> logger, 
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
            if (!ModelState.IsValid || model == null)
            {
                return BadRequest("Register Product: Parameters invalid");
            }

            var registerProductModel = new RegisterProductModel(model.Name, model.Description);
            var success = await _productAppService.RegisterProductAsync(registerProductModel);

            if (HasNotification())
                return BadRequest(new ApiResult("Product Registered", false, GetNotification()));

            return Ok("Success");
        }
       
    }
}