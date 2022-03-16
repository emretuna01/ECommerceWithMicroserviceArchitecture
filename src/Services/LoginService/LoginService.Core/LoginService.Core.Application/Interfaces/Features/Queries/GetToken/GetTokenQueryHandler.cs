using AutoMapper;
using LoginService.Core.Application.Interfaces.Dtos;
using LoginService.Core.Application.Interfaces.JwtHandler;
using LoginService.Core.Application.Interfaces.UnitOfWorks;
using LoginService.Core.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoginService.Core.Application.Interfaces.Features.Queries.GetToken
{
    public class GetTokenQueryHandler : IRequestHandler<GetTokenQueryRequest, GetTokenQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITokenHandler _tokenHandler;

        public GetTokenQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ITokenHandler tokenHandler)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokenHandler = tokenHandler;
        }

        public async Task<GetTokenQueryResponse> Handle(GetTokenQueryRequest request, CancellationToken cancellationToken)
        {
            User user=null;
            GetTokenQueryResponse getTokenQueryResponse= new GetTokenQueryResponse();
            if (request != null)            
               user= await _unitOfWork.UserRepository.GetWhereAsync(z => z.Username==request.Username && z.Password==request.Password);

            TokenDto tokenDto=null;
            if (user != null)
                tokenDto= _tokenHandler.CreateAccessToken(20);

            if (tokenDto != null)
            {  getTokenQueryResponse = _mapper.Map<GetTokenQueryResponse>(tokenDto);
                getTokenQueryResponse.Message = "Kullanıcı adı ve şifre doğru";
                return getTokenQueryResponse;
            }
            else
            {
                getTokenQueryResponse.Message = "Kullanıcı adı ya da şifre bulunamadı";
            }

            return getTokenQueryResponse;

        }
    }
}
