using AutoMapper;
using CatalogService.Core.Application.Interfaces.Features.Queries.GetAllCatalogItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tCatalogItem = CatalogService.Core.Domain.Entities.CatalogItem;

namespace CatalogService.Core.Application.Profiles.CatalogItem
{
    public class GetAllCatalogItemProfiler : Profile
    {
        public GetAllCatalogItemProfiler()
        {
            CreateMap<tCatalogItem, GetAllCatalogItemQueryResponse>().ReverseMap();
        }
    }
}
