using AutoMapper;
using CatalogService.Core.Application.Interfaces.Features.Commands.CreateCatalogItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tCatalogItem = CatalogService.Core.Domain.Entities.CatalogItem;


namespace CatalogService.Core.Application.Profiles.CatalogItem
{
    public class CreateCatalogItemProfiler : Profile
    {
        public CreateCatalogItemProfiler()
        {
            CreateMap<tCatalogItem, CreateCatalogItemCommandRequest>();
        }
    }
}
