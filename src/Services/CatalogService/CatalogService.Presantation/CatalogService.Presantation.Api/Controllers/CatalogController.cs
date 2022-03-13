using CatalogService.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CatalogService.Presantation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        
        [HttpGet("GetCatalogItem")]
        public List<CatalogItem> GetCatalogItem()
        {
            return new List<CatalogItem>()
            {
                new CatalogItem() { Name = "PC",AvailableStock=100,CatalogBrandId=10,Description="Pc with extension pack"},
                new CatalogItem() { Name = "Tv",AvailableStock=200,CatalogBrandId=20,Description="Tv with insurance pack"},
                new CatalogItem() { Name = "Watch",AvailableStock=300,CatalogBrandId=30,Description="Just Watch"},
            };
        }

        [HttpPost("AddCatalogItem")]
        public int AddCatalogItem()
        {
            throw new NotImplementedException();
        }



    }
}
