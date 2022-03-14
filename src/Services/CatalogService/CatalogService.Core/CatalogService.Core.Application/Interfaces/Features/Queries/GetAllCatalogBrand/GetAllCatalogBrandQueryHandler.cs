using AutoMapper;
using CatalogService.Core.Application.Interfaces.UnitOfWorks;
using CatalogService.Core.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CatalogService.Core.Application.Interfaces.Features.Queries.GetAllCatalogBrand
{
    public class GetAllCatalogBrandQueryHandler : IRequestHandler<GetAllCatalogBrandQueryRequest, List<GetAllCatalogBrandQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCatalogBrandQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<GetAllCatalogBrandQueryResponse>> Handle(GetAllCatalogBrandQueryRequest request, CancellationToken cancellationToken)
        {
            List<CatalogBrand> responses = await _unitOfWork.CatalogBrandRepository.GetListAsync();
            return  _mapper.Map <List<GetAllCatalogBrandQueryResponse>>(responses);
        }
    }
}
