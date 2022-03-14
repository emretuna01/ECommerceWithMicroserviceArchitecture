using CatalogService.Core.Application.Interfaces.Features.Commands.CreateCatalogBrand;
using CatalogService.Core.Application.Interfaces.Features.Commands.CreateCatalogItem;
using CatalogService.Core.Application.Interfaces.Features.Commands.CreateCatalogType;
using CatalogService.Core.Application.Interfaces.Features.Queries.GetAllCatalogBrand;
using CatalogService.Core.Application.Interfaces.Features.Queries.GetAllCatalogItem;
using CatalogService.Core.Application.Interfaces.Features.Queries.GetAllCatalogType;
using CatalogService.Core.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CatalogService.Presantation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CatalogController : ControllerBase
    {
        private readonly IMediator _mediator;

        [HttpGet("GetAllCatalogBrand")]
        public async Task<List<GetAllCatalogBrandQueryResponse>> GetAllCatalogBrand()
        {
            return await _mediator.Send(new GetAllCatalogBrandQueryRequest());
        }

        [HttpGet("GetAllCatalogItem")]
        public async Task<List<GetAllCatalogItemQueryResponse>> GetAllCatalogItem()
        {
            return await _mediator.Send(new GetAllCatalogItemQueryRequest());
        }

        [HttpGet("GetAllCatalogType")]
        public async Task<List<GetAllCatalogTypeQueryResponse>> GetAllCatalogType()
        {
            return await _mediator.Send(new GetAllCatalogTypeQueryRequest());
        }


        [HttpPost("CreateCatalogBrand")]
        public async Task<CreateCatalogBrandCommandResponse> CreateCatalogBrand(CreateCatalogBrandCommandRequest createCatalogBrandCommandRequest)
        {
            return await _mediator.Send(createCatalogBrandCommandRequest);
        }

        [HttpPost("CreateCatalogItem")]
        public async Task<CreateCatalogItemCommandResponse> CreateCatalogItem(CreateCatalogItemCommandRequest createCatalogItemCommandRequest)
        {
            return await _mediator.Send(createCatalogItemCommandRequest);
        }

        [HttpPost("CreateCatalogType")]
        public async Task<CreateCatalogTypeCommandResponse> CreateCatalogItem(CreateCatalogTypeCommandRequest createCatalogTypeCommandRequest)
        {
            return await _mediator.Send(createCatalogTypeCommandRequest);
        }


    }
}
