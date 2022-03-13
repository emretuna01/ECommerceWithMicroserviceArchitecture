﻿using LoginService.Core.Application.Interfaces.Dtos;
using LoginService.Core.Application.Interfaces.Features.Commands.CreateUser;
using LoginService.Core.Application.Interfaces.Features.Queries.GetAllUsers;
using LoginService.Core.Application.Interfaces.JwtHandler;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoginService.Presantation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ITokenHandler _tokenHandler;

        public UserController(IMediator mediator, ITokenHandler tokenHandler)
        {
            _mediator = mediator;
            _tokenHandler = tokenHandler;
        }

        
        [HttpGet("AllUsers")]
        public Task<List<GetAllUsersQueryResponse>> GetAllUsers()
        {
            return _mediator.Send(new GetAllUsersQueryRequest());
        }


        [HttpPost("AddUser")]
        public async Task<CreateUserCommandResponse> AddUser([FromBody] CreateUserCommandRequest createUserCommandRequest)
        {
            return await _mediator.Send(createUserCommandRequest);
        }

        [HttpGet("Token")]
        public TokenDto CreateToken()
        {
            return _tokenHandler.CreateAccessToken(1);
        }
    }
}
