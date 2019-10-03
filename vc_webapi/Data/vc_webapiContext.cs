using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using vc_webapi.Model;

namespace vc_webapi.Models
{
    public class Vc_webapiContext : DbContext
    {
        public Vc_webapiContext (DbContextOptions<Vc_webapiContext> options)
            : base(options)
        {
        }

        public DbSet<vc_webapi.Model.Video> Video { get; set; }
    }
}
