using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vc_webapi.Attributes
{
    public class RequestEncodingContentTypeAttribute : Attribute
    {
        public string MediaType { get; set; }
        public string[] ParameterNames { get; set; }
        public string[] ContentTypes { get; set; }
    }
}
