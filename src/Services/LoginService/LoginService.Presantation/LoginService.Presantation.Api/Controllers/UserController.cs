using LoginService.Core.Application.Interfaces.Features.Commands.CreateUser;
using LoginService.Core.Application.Interfaces.Features.Queries.GetAllUsers;
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

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<UserController>
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

        
    }
}
