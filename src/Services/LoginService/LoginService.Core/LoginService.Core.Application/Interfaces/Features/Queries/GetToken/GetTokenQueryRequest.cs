using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginService.Core.Application.Interfaces.Features.Queries.GetToken
{
    public class GetTokenQueryRequest:IRequest<GetTokenQueryResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
