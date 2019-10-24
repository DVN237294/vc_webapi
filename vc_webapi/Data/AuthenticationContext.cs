using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vc_webapi.Model;

namespace vc_webapi.Data
{
    public class AuthenticationContext : IdentityDbContext
    {
        public AuthenticationContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<IdentityUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var hasher = new PasswordHasher<IdentityUser>();
            builder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                UserName = "teststudent",
                NormalizedUserName = "TESTSTUDENT",
                Email = "some@mail.com",
                NormalizedEmail = "SOME@MAIL.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "bpr2019"),
                SecurityStamp = string.Empty
            });

            builder.Entity<IdentityUserClaim<string>>().HasData(new IdentityUserClaim<string>()
            {
                Id = 100,
                UserId = "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                ClaimType = "UserName",
                ClaimValue = "teststudent"
            });
        }
    }
}
