using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vc_webapi.Model.API
{
    public class AddSessionModel
    {
        public DateTime Date { get; set; }
        public IList<Video> Recordings { get; set; }
        public IEnumerable<long> ParticipantUserIds { get; set; }
    }
}
