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


namespace CatalogService.Core.Application.Interfaces.Features.Commands.CreateCatalogBrand
{
    public class CreateCatalogBrandCommandHandler : IRequestHandler<CreateCatalogBrandCommandRequest, CreateCatalogBrandCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _autoMapper;


        public CreateCatalogBrandCommandHandler(IUnitOfWork unitOfWork, IMapper autoMapper)
        {
            _unitOfWork = unitOfWork;
            _autoMapper = autoMapper;
        }

        public async Task<CreateCatalogBrandCommandResponse> Handle(CreateCatalogBrandCommandRequest request, CancellationToken cancellationToken)
        {
            CatalogBrand catalogBrand  = _autoMapper.Map<CatalogBrand>(request);
            EntityState result = await _unitOfWork.CatalogBrandRepository.AddAsync(catalogBrand);
            int affectedRowCount= await _unitOfWork.SaveChangesAsync();
            if (result == EntityState.Added && affectedRowCount>0)
            {
                return new CreateCatalogBrandCommandResponse
                {
                    Message = EntityState.Added.ToString(),
                    Succeed = true
                };
            }
            else
            {
                return new CreateCatalogBrandCommandResponse
                {
                    Message = result.ToString(),
                    Succeed = false
                };

            }

        }

    }
}
