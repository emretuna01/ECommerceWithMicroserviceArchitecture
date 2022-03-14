using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Core.Application.Interfaces.Features.Queries.GetAllCatalogBrand
{
    public class GetAllCatalogBrandQueryRequest:IRequest<List<GetAllCatalogBrandQueryResponse>>
    {
    }
}
