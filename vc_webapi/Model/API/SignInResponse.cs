using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vc_webapi.Model.API
{
    public class AuthenticationResponse
    {
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}
