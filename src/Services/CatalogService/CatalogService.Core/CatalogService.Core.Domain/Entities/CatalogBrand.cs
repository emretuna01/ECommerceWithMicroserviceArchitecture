﻿using CatalogService.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Core.Domain.Entities
{
    public class CatalogBrand: BaseEntity
    {
        public string Brand { get; set; }
    }
}
