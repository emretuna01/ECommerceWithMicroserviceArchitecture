﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Core.Application.Interfaces.Features.Commands.CreateCatalogBrand
{
    public class CreateCatalogTypeCommandRequest : IRequest<CreateCatalogTypeCommandResponse>
    {
        public string Brand { get; set; }
    }
}
