using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace vc_webapi.Model
{
    public class Session
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; internal set; }
        public DateTime Date { get; set; }
        public ICollection<Video> Recordings { get; set; }
        [JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public ICollection<Participant> DbParticipants { get; set; } = new List<Participant>();
        [NotMapped]
        public IEnumerable<User> Participants
        {
            get => DbParticipants.Count > 0 ? DbParticipants.Select(us => us.User) : null;
            set
            {
                foreach(var u in value)
                {
                    DbParticipants.Add(new Participant
                    {
                        Session = this,
                        User = u
                    });
                }
            }
        }
    }
}
