using System;
using System.Collections.Generic;

namespace vc_webapi.Model.API
{
    public class RoomRecordingSchedule
    {
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public ICollection<ScheduledSession> ScheduledSessions { get; set; }
    }
}
