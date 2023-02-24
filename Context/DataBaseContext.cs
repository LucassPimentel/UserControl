using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserControl.Models;

namespace UserControl.Context
{
    public class DataBaseContext : IdentityDbContext<CustomIdentityUser, IdentityRole<int>, int>
    {
        private IConfiguration _config;
        public DataBaseContext(DbContextOptions<DataBaseContext> opts, IConfiguration config) : base(opts)
        {
            _config = config;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var hasher = new PasswordHasher<CustomIdentityUser>();

            var admin = new CustomIdentityUser()
            {
                Id = 9999,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            admin.PasswordHash = hasher.HashPassword(admin,Environment.GetEnvironmentVariable("ADMIN_PASSWORD"));

            builder.Entity<CustomIdentityUser>().HasData(admin);

            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int>
                {
                    Id = 9999,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                });

            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int>
                {
                    Id = 9998,
                    Name = "Regular",
                    NormalizedName = "REGULAR"
                });

            builder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int>
                {
                    UserId = 9999,
                    RoleId = 9999
                });
        }
    }
}
