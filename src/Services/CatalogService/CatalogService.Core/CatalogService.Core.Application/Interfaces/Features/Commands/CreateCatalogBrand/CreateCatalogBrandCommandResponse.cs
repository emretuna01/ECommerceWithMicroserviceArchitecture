using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Core.Application.Interfaces.Features.Commands.CreateCatalogBrand
{
    public class CreateCatalogBrandCommandResponse
    {
        public bool Succeed { get; set; }
        public string Message { get; set; }
    }
}
