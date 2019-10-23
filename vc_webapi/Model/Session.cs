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
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Video> Recordings { get; set; }
        [JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public ICollection<UserSession> UserSessions { get; set; } = new List<UserSession>();
        [NotMapped]
        public IEnumerable<User> Participants
        {
            get => UserSessions.Count > 0 ? UserSessions.Select(us => us.User) : null;
            set
            {
                foreach(var u in value)
                {
                    UserSessions.Add(new UserSession
                    {
                        Session = this,
                        User = u
                    });
                }
            }
        }
    }
}
