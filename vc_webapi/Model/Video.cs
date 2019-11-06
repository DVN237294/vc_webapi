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
        [Required]
        public VideoProperties Properties { get; set; }
        public ICollection<Comment> Comments { get; set; }
        [Required]
        public string Name { get; set; }
        public string ThumbnailURL { get; set; }
        [Required]
        public DateTime RecordTimeUtc { get; set; }
        public string StreamUrl { get; set; }
    }
}
