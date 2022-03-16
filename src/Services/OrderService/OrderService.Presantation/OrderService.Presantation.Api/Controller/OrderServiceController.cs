using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderService.Core.Application.Interfaces.UnitOfWorks;
using OrderService.Infrastructure.Extensions.ExtensionModules.RabbitMqModule;
using OrderService.Infrastructure.Persistance.Services;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderService.Presantation.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderServiceController : ControllerBase
    {
        private readonly RabbitMqService _rabbitMqService;
        private readonly IUnitOfWork _unitOfWork;

        public OrderServiceController(RabbitMqService rabbitMqService, IUnitOfWork unitOfWork)
        {
            _rabbitMqService = rabbitMqService;
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task GetListenRabbitMq()
        {
            await _rabbitMqService.RabbitMqListener();            
          
        }
    }
}
