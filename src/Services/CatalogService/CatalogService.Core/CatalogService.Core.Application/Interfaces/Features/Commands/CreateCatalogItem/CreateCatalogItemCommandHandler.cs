using AutoMapper;
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


namespace CatalogService.Core.Application.Interfaces.Features.Commands.CreateCatalogItem
{
    public class CreateCatalogItemCommandHandler : IRequestHandler<CreateCatalogItemCommandRequest, CreateCatalogItemCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _autoMapper;


        public CreateCatalogItemCommandHandler(IUnitOfWork unitOfWork, IMapper autoMapper)
        {
            _unitOfWork = unitOfWork;
            _autoMapper = autoMapper;
        }

        public async Task<CreateCatalogItemCommandResponse> Handle(CreateCatalogItemCommandRequest request, CancellationToken cancellationToken)
        {
            CatalogItem catalogItem= _autoMapper.Map<CatalogItem>(request);
            EntityState result = await _unitOfWork.CatalogItemRepository.AddAsync(catalogItem);
            int affectedRowCount= await _unitOfWork.SaveChangesAsync();
            if (result == EntityState.Added && affectedRowCount>0)
            {
                return new CreateCatalogItemCommandResponse
                {
                    Message = EntityState.Added.ToString(),
                    Succeed = true
                };
            }
            else
            {
                return new CreateCatalogItemCommandResponse
                {
                    Message = result.ToString(),
                    Succeed = false
                };

            }

        }

    }
}
