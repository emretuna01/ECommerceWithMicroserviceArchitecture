using AutoMapper;
using CatalogService.Core.Application.Interfaces.Features.Queries.GetAllCatalogBrand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tCatalogBrand = CatalogService.Core.Domain.Entities.CatalogBrand;
namespace CatalogService.Core.Application.Profiles.CatalogBrand
{
    public class GetAllCatalogBrandProfiler:Profile
    {
        public GetAllCatalogBrandProfiler()
        {
            CreateMap<tCatalogBrand, GetAllCatalogBrandQueryResponse>().ReverseMap();
        }
    }
}
