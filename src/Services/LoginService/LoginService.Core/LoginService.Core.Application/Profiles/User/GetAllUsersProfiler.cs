using AutoMapper;
using LoginService.Core.Application.Interfaces.Features.Queries.GetAllUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginService.Core.Application.Profiles.User
{
    public class GetAllUsersProfiler:Profile
    {
        public GetAllUsersProfiler()
        {
            CreateMap<LoginService.Core.Domain.Entities.User, GetAllUsersQueryResponse>().ReverseMap();
        }
    }
}
