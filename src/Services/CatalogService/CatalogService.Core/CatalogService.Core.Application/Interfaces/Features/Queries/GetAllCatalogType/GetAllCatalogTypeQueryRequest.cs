using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Core.Application.Interfaces.Features.Queries.GetAllCatalogType
{
    public class GetAllCatalogTypeQueryRequest:IRequest<List<GetAllCatalogTypeQueryResponse>>
    {
    }
}
