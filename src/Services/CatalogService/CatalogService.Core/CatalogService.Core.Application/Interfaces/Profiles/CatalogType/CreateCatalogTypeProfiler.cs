using AutoMapper;
using CatalogService.Core.Application.Interfaces.Features.Commands.CreateCatalogBrand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tCatalogType = CatalogService.Core.Domain.Entities.CatalogType;

namespace CatalogService.Core.Application.Interfaces.Profiles.CatalogType
{
    public class CreateCatalogTypeProfiler:Profile
    {
        public CreateCatalogTypeProfiler()
        {
            CreateMap<tCatalogType, CreateCatalogTypeCommandRequest>().ReverseMap();
        }
    }
}
