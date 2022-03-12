using LoginService.Core.Application.Interfaces.Features.Commands.CreateUser;
using LoginService.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace LoginService.Core.Application.Profiles.User
{
    public class AddUserCreateProfiler: Profile
    {
        public AddUserCreateProfiler()
        {
            
            CreateMap<CreateUserCommandRequest, LoginService.Core.Domain.Entities.User > ().ReverseMap();
        }
    }
}
