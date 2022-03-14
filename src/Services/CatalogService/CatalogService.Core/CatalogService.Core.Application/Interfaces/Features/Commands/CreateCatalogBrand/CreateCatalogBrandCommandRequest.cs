using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Core.Application.Interfaces.Features.Commands.CreateCatalogBrand
{
    public class CreateCatalogBrandCommandRequest : IRequest<CreateCatalogBrandCommandResponse>
    {
        public string Brand { get; set; }
    }
}
