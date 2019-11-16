using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace vc_webapi.Model
{
    public class ScheduledSession
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; internal set; }
        [Required]
        [Range(1, long.MaxValue)]
        public long WebuntisId { get; set; }
        [Required]
        [Range(1, long.MaxValue)]
        public long WebuntisCourseId { get; set; }
        public long CourseId { get; set; }
        public Course Course { get; }
        [Required]
        [Range(1, long.MaxValue)]
        public long RoomId { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public Room Room { get; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        public long[] WebuntisTeacherIds { get; set; }
    }
}
