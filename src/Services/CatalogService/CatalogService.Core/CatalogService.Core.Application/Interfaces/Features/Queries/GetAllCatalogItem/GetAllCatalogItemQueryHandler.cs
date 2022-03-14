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

namespace CatalogService.Core.Application.Interfaces.Features.Queries.GetAllCatalogItem
{
    public class GetAllCatalogItemQueryHandler : IRequestHandler<GetAllCatalogItemQueryRequest, List<GetAllCatalogItemQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCatalogItemQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<GetAllCatalogItemQueryResponse>> Handle(GetAllCatalogItemQueryRequest request, CancellationToken cancellationToken)
        {
            List<CatalogItem> responses= await _unitOfWork.CatalogItemRepository.GetListAsync();
            return  _mapper.Map <List<GetAllCatalogItemQueryResponse>>(responses);
        }
    }
}
