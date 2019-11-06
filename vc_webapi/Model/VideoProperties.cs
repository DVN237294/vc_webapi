using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace vc_webapi.Model
{
    public class VideoProperties
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public long Id { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string VirtualFilePath { get; set; }
        public long FileSize { get; set; }
        [Required]
        public string MimeType { get; set; }
        [Required]
        public long Duration { get; set; }
        [Required]
        public string ContainerExt { get; set; }
    }
}
