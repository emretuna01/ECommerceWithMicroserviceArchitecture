using AutoMapper;
using CatalogService.Core.Application.Interfaces.Features.Queries.GetAllCatalogType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tCatalogType = CatalogService.Core.Domain.Entities.CatalogType;

namespace CatalogService.Core.Application.Profiles.CatalogType
{
    public class GetAllCatalogTypeProfiler : Profile
    {
        public GetAllCatalogTypeProfiler()
        {
            CreateMap<tCatalogType, GetAllCatalogTypeQueryResponse>().ReverseMap();
        }
    }
}
