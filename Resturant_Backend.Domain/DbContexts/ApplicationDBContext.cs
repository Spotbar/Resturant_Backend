using Resturant_Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Resturant_Backend.Domain.DbContexts
{
    //*************** Migration ***************
    //1- Add-Migration InitialMigration
    //2- Update-Database

    public class ApplicationDBContext : IdentityDbContext<ApplicationUser>
    {
        //public DbSet<Group> Groups { get; set; } = null!;
        //public DbSet<User> Users { get; set; } = null!;
        //public DbSet<UserGroup> UserGroups { get; set; } = null!;

        public DbSet<Restaurant> Restaurants { get; set; } = null!;
        public DbSet<DateCredit> DateCredits { get; set; } = null!;
        public DbSet<Factor> Factors { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<UserOrder> UserOrders { get; set; } = null!;
        public  DbSet<UserRefreshTokens> UserRefreshToken { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");


        }
    }
}
