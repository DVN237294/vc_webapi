﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vc_webapi.Model
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
    }
}
