using AutoMapper;
using CatalogService.Core.Application.Interfaces.Features.Commands.CreateCatalogBrand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tCatalogBrand = CatalogService.Core.Domain.Entities.CatalogBrand;

namespace CatalogService.Core.Application.Profiles.CatalogBrand
{
    public class CreateCatalogBrandProfiler:Profile
    {
        public CreateCatalogBrandProfiler()
        {
            CreateMap<tCatalogBrand, CreateCatalogBrandCommandRequest>().ReverseMap();
        }
    }
}
