using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginService.Core.Application.Interfaces.Features.Commands.CreateUser
{
    public class CreateUserCommandResponse
    {
        public bool Succeed { get; set; }
        public string Message { get; set; }
    }
}
