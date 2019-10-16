using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vc_webapi.Model
{
    public class UserSignupModel
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
    }
}
