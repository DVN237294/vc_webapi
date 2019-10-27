using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using vc_webapi.Model;
using vc_webapi.Model.Users;

namespace vc_webapi.Data
{
    public class Vc_webapiContext : DbContext
    {
        public Vc_webapiContext (DbContextOptions<Vc_webapiContext> options)
            : base(options)
        { }

        public DbSet<Video> Videos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasIndex(b => b.UserName)
                .IsUnique();
            builder.Entity<Admin>();
            builder.Entity<Student>();

            builder.Entity<UserSession>()
                .HasOne(x => x.Session)
                .WithMany(x => x.UserSessions)
                .HasForeignKey(x => x.SessionId);

            builder.Entity<UserSession>()
                .HasOne(x => x.User)
                .WithMany(x => x.Sessions)
                .HasForeignKey(x => x.UserId);
        }
    }
}
