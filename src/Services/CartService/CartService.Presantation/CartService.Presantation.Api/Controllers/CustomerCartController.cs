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

        public CustomerCartController(RedisCacheService redisCacheService)
        {
            _redisCacheService = redisCacheService;
        }

        [HttpPost("AddToRedis")]
        public async Task<bool> AddToRedis([FromBody] CustomerCart customerCart)
        {
           return await _redisCacheService.Set(customerCart.ObjectId.ToString(), customerCart);
        }

    }
}
