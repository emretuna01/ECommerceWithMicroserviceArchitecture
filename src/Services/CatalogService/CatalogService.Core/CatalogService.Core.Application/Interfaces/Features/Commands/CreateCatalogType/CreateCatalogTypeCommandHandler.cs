using AutoMapper;
using CatalogService.Core.Application.Interfaces.Features.Commands.CreateCatalogItem;
using CatalogService.Core.Application.Interfaces.UnitOfWorks;
using CatalogService.Core.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace CatalogService.Core.Application.Interfaces.Features.Commands.CreateCatalogType
{
    public class CreateCatalogTypeCommandHandler : IRequestHandler<CreateCatalogTypeCommandRequest, CreateCatalogTypeCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _autoMapper;


        public CreateCatalogTypeCommandHandler(IUnitOfWork unitOfWork, IMapper autoMapper)
        {
            _unitOfWork = unitOfWork;
            _autoMapper = autoMapper;
        }

        public async Task<CreateCatalogTypeCommandResponse> Handle(CreateCatalogTypeCommandRequest request, CancellationToken cancellationToken)
        {
            CatalogType catalogType = _autoMapper.Map<CatalogType>(request);
            EntityState result = await _unitOfWork.CatalogTypeRepository.AddAsync(catalogType);
            int affectedRowCount= await _unitOfWork.SaveChangesAsync();
            if (result == EntityState.Added && affectedRowCount>0)
            {
                return new CreateCatalogTypeCommandResponse
                {
                    Message = EntityState.Added.ToString(),
                    Succeed = true
                };
            }
            else
            {
                return new CreateCatalogTypeCommandResponse
                {
                    Message = result.ToString(),
                    Succeed = false
                };

            }

        }

    }
}
