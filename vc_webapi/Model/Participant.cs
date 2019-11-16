using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace vc_webapi.Model
{
    public class Participant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; internal set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public long SessionId { get; set; }
        public Session Session { get; set; }

    }
}
