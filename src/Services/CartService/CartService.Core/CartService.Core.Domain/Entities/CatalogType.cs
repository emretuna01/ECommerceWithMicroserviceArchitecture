using CartService.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartService.Core.Domain.Entities
{
    public class CatalogType : BaseEntity
    {
        public string Type { get; set; }
    }
}
