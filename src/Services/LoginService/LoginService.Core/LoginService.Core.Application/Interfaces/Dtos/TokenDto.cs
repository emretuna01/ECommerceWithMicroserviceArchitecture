using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginService.Core.Application.Interfaces.Dtos
{
    public class TokenDto
    {
        public string AccessToken { get; set; }
        public DateTime ExpireTime { get; set; }
    }
}
