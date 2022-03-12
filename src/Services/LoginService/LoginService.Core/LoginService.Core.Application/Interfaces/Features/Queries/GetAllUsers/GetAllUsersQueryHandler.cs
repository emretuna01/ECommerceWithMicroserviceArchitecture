using AutoMapper;
using LoginService.Core.Application.Interfaces.UnitOfWorks;
using LoginService.Core.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoginService.Core.Application.Interfaces.Features.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQueryRequest, List<GetAllUsersQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<GetAllUsersQueryResponse>> Handle(GetAllUsersQueryRequest request, CancellationToken cancellationToken)
        {
            List<User> getAllUsersQueryResponses= await _unitOfWork.UserRepository.GetListAsync();
            return  _mapper.Map <List<GetAllUsersQueryResponse>>(getAllUsersQueryResponses);
        }
    }
}
