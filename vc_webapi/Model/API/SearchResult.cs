using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vc_webapi.Model.API
{
    public class SearchResult
    {
        public IEnumerable<Video> Videos { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}
