using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace vc_webapi.Model
{
    public class Video
    {
        [Key]
        public long Id { get; set; }
        public string URL { get; set; }
        public long Duration { get; set; }
        public string Name { get; set; }

    }
}
