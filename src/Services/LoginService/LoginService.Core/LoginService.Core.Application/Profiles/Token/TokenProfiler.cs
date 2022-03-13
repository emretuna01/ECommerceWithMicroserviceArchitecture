using AutoMapper;
using LoginService.Core.Application.Interfaces.Dtos;
using LoginService.Core.Application.Interfaces.Features.Queries.GetToken;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginService.Core.Application.Profiles.Token
{
    public class TokenProfiler:Profile
    {
        public TokenProfiler()
        {
            CreateMap<TokenDto,GetTokenQueryResponse>().ReverseMap();
        }
    }
}
