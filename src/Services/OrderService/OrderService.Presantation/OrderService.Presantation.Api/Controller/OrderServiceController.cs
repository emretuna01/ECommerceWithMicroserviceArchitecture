using Microsoft.AspNetCore.Mvc;
using OrderService.Infrastructure.Extensions.ExtensionModules.RabbitMqModule;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderService.Presantation.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderServiceController : ControllerBase
    {
        private readonly RabbitMqConsumerModule _rabbitMqConsumerModule;

        public OrderServiceController(RabbitMqConsumerModule rabbitMqConsumerModule)
        {
            _rabbitMqConsumerModule = rabbitMqConsumerModule;
            _rabbitMqConsumerModule.RabbitMqListener();
        }

        // GET: api/<OrderServiceController>
        [HttpGet]
        public string Get()
        {
            return "test";
        }
    }
}
