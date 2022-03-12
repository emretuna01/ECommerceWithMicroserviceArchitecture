using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginService.Core.Application.Interfaces.Features.Queries.GetAllUsers
{
    public class GetAllUsersQueryRequest:IRequest<List<GetAllUsersQueryResponse>>
    {
    }
}
