using LoginService.Core.Application.Configurations;
using LoginService.Core.Application.Interfaces.Dtos;
using LoginService.Core.Application.Interfaces.JwtHandler;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginService.Presantation.Api.JwtHandler
{
    public class TokenHandler : ITokenHandler
    {
        private readonly TokenDto _tokenDto;
        private readonly JwtConfiguration _configuration;

        public TokenHandler(TokenDto tokenDto, IOptions<JwtConfiguration> configuration)
        {
            _tokenDto = tokenDto;
            _configuration = configuration.Value;
        }

        public TokenDto CreateAccessToken(int expireMinutes)
        {
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.SecretKey));

            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            _tokenDto.ExpireTime = DateTime.Now.AddMinutes(expireMinutes);
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                       issuer: _configuration.Issuer,
                       audience: _configuration.Audidence,
                       expires: _tokenDto.ExpireTime,
                       notBefore: DateTime.Now,
                       signingCredentials: signingCredentials

                );

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            _tokenDto.AccessToken = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);
            return _tokenDto;

        }

        public string CreateRefreshToken()
        {
            throw new NotImplementedException();
        }
    }
}
