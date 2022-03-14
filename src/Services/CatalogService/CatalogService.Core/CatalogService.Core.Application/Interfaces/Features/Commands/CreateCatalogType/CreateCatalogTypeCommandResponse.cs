using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Core.Application.Interfaces.Features.Commands.CreateCatalogType
{
    public class CreateCatalogItemCommandResponse
    {
        public bool Succeed { get; set; }
        public string Message { get; set; }
    }
}
