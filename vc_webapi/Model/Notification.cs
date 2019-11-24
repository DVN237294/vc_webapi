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
        public User user { get; set; }
        public long userId { get; set; }
        public string message { get; set; }
        public DateTime date { get; set; }
    }
}
