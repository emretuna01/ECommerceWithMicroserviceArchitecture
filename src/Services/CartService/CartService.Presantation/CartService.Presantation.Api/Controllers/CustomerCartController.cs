using CartService.Core.Domain.Entities;
using CartService.Infrastructure.Extensions.ExtensionModules.RabbitMqModule;
using CartService.Presantation.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CartService.Presantation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerCartController : ControllerBase
    {
        private readonly RedisService _redisService;
        private readonly RabbitMqBaseModule _rabbitMqBaseModule;
        private CustomerCart _customerCart;

        public CustomerCartController(RedisService redisService, RabbitMqBaseModule rabbitMqBaseModule)
        {
            _redisService = redisService;
            _rabbitMqBaseModule = rabbitMqBaseModule;
            _customerCart = new CustomerCart
            {
                ObjectId = Guid.NewGuid(),
                BuyerId = Guid.NewGuid().ToString(),
                Items = new List<CatalogItem>
                {
                    new CatalogItem()
                    {
                        ObjectId= Guid.NewGuid(),
                        Name = "item 1",
                        Description="emre",
                        CatalogBrandId = 100
                    }
                }
            };
        }

        [HttpGet("InsertRedis")]
        public void InsertRedis()
        {
            _redisService.GetDb().StringSetAsync(_customerCart.ObjectId.ToString(), JsonSerializer.Serialize(_customerCart));
        }

        [HttpGet("SendMessageToRabbitMq")]
        public void SendMessageToRabbitMq()
        {
            _rabbitMqBaseModule.SendMessage(_customerCart);
        }
    }
}
