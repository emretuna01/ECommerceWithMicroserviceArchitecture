using LoginService.Core.Application.Interfaces.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginService.Core.Application.Interfaces.JwtHandler
{
    public interface ITokenHandler
    {
        public TokenDto CreateAccessToken(int expireMinutes);
        string CreateRefreshToken();
    }
}
