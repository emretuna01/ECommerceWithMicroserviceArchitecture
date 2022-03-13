using CartService.Core.Domain.Entities;
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

        public CustomerCartController(RedisService redisService)
        {
            _redisService = redisService;
        }

        [HttpGet]
        public void InsertRedis()
        {
            var cc = new CustomerCart
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


            _redisService.GetDb().StringSetAsync(cc.ObjectId.ToString(), JsonSerializer.Serialize(cc));


        }


    }
}
