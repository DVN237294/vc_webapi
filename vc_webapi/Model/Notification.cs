using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace vc_webapi.Model
{
    public class Notification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public User User { get; set; }
        public long UserId { get; set; }
        public string Message { get; set; }
        public DateTime NotificationTimeUtc { get; set; }
        public bool Dismissed { get; set; }
        public RouterLink RouterLink { get; set; }
        public ICollection<RouterLinkParam> RouterLinkParameters { get; set; }
    }
}
