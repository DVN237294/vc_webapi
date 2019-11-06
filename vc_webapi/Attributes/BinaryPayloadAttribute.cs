using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vc_webapi.Attributes
{
    public class BinaryPayloadAttribute : Attribute
    {
        public string Format { get; set; } = "binary";
        public string MediaType { get; set; } = "application/octet-stream";
        public bool Required { get; set; } = true;
        public string ParameterName { get; set; } = "payload";
    }
}
