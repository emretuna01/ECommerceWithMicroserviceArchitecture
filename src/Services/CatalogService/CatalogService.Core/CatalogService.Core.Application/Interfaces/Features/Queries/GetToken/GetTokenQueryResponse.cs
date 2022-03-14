using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginService.Core.Application.Interfaces.Features.Queries.GetToken
{
    public class GetTokenQueryResponse
    {
        public string AccessToken { get; set; }
        public DateTime ExpireTime { get; set; }
    }
}
