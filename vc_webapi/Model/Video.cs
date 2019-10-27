using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vc_webapi.Model
{
    public class Video
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string URL { get; set; }
        public long Duration { get; set; }
        public List<Comment> Comments { get; set; }
        public string Name { get; set; }
        public string ThumbnailURL { get; set; }
        public DateTime RecordTimeUtc { get; set; }
    }
}
