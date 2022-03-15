using CartService.Core.Domain.Entities;
using CartService.Infrastructure.Extensions.ExtensionModules.RabbitMqModule;
using CartService.Infrastructure.Persistance.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CartService.Presantation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerCartController : ControllerBase
    {
        private readonly RedisCacheService _redisCacheService;
        private readonly RabbitMqService _rabbitMqService;

        public CustomerCartController(RedisCacheService redisCacheService, RabbitMqService rabbitMqBaseModule)
        {
            _redisCacheService = redisCacheService;
            _rabbitMqService = rabbitMqBaseModule;
        }

        [HttpPost("AddToRedis")]
        public async Task<bool> AddToRedis([FromBody] CustomerCart customerCart)
        {
           return await _redisCacheService.Set(customerCart.ObjectId.ToString(), customerCart);
        }

        [HttpGet("SendCustomerCartToRabbitMq")]
        public bool SendCustomerCartToRabbitMq([FromBody] CustomerCart customerCart)
        {
            customerCart.CartStatus = CartStatus.Done;
            _rabbitMqService.SendMessage(customerCart);
            return customerCart.CartStatus==CartStatus.Done ? true:false;
        }

    }
}
