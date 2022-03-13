using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginService.Core.Application.Configurations
{
    public class JwtConfiguration
    {
        public string Audidence { get; set; }
        public string Issuer { get; set; }
        public string SecretKey { get; set; }
    }
}
