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

namespace CatalogService.Core.Application.Interfaces.Features.Queries.GetAllCatalogType
{
    public class GetAllCatalogTypeQueryHandler : IRequestHandler<GetAllCatalogTypeQueryRequest, List<GetAllCatalogTypeQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCatalogTypeQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<GetAllCatalogTypeQueryResponse>> Handle(GetAllCatalogTypeQueryRequest request, CancellationToken cancellationToken)
        {
            List<CatalogBrand> responses = await _unitOfWork.CatalogBrandRepository.GetListAsync();
            return  _mapper.Map <List<GetAllCatalogTypeQueryResponse>>(responses);
        }
    }
}
