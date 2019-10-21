using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace vc_webapi.Model.API
{
    public class EnrollUserModel
    {
        [Required]
        public long UserId { get; set; }
        [Required]
        public long CourseId { get; set; }
    }
}
