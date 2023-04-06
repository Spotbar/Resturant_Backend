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
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

           

            //var group1 = new Group() { Name = "IT" };
            //var group2 = new Group() { Name = "لجستیک" };

            //var user1 = new ApplicationUser() { Name = "حسن الفت",NationalCode = "3240486611", UserName = "3240486611"  };
            //var user2 = new ApplicationUser() { Name = "الهام شهری", NationalCode = "3240812282",UserName= "3240812282" };

          //  var userGroup1 = new UserGroup() { GroupId = group1.Id ,UserId= user1.Id };
           // var userGroup2 = new UserGroup() { GroupId = group1.Id, UserId = user2.Id };


            //var restuarant1 = new Restaurant( "گلی خانم", "0831") ;
            //var restuarant2 = new Restaurant("باغ گیلاس",   "0831") ;
            //var restuarant3 = new Restaurant("پارسی", "0831");

            //var factor1 = new Factor()
            //{
            //    DeliveryCost = 15000,
            //    FactorAmount = 200000,
            //    FactorDate = DateTimeOffset.Now,
            //    FactorNummber = "-1",
            //    IsClosed = false,
            //    IsDeliveryByCompany = false,
            //    RestaurantId = restuarant1.Id
            //};
            //var factor2 = new Factor()
            //{
            //    DeliveryCost = 15000,
            //    FactorAmount = 200000,
            //    FactorDate = DateTimeOffset.Now,
            //    FactorNummber = "-1",
            //    IsClosed = false,
            //    IsDeliveryByCompany = false,
            //    RestaurantId = restuarant2.Id
            //};
            //var factor3 = new Factor()
            //{
            //    DeliveryCost = 15000,
            //    FactorAmount = 200000,
            //    FactorDate = DateTimeOffset.Now,
            //    FactorNummber = "-1",
            //    IsClosed = false,
            //    IsDeliveryByCompany = false,
            //    RestaurantId = restuarant3.Id
            //};

            //var oredr1 = new Order() { Name = "کوبیده",Cost=120000,FactorId=factor1.Id,IsAccept=true,IsShared=false };
            //var oredr2 = new Order() { Name = "عدس پلو", Cost = 800000, FactorId = factor1.Id, IsAccept = true, IsShared = true };

            //var userOrder1 = new UserOrder() { UserId= user1.Id,OrderId=oredr1.Id,Amount= 120000 };
            //var userOrder2 = new UserOrder() { UserId = user2.Id, OrderId = oredr2.Id, Amount = 40000 };
            //var userOrder3 = new UserOrder() { UserId = user1.Id, OrderId = oredr2.Id, Amount = 40000 };


            /////////////////////

            //modelBuilder.Entity<User>().HasData(user1, user2);
            //modelBuilder.Entity<Group>().HasData(group1, group2);
            //modelBuilder.Entity<UserGroup>().HasData(userGroup1, userGroup2);


            //modelBuilder.Entity<DateCredit>()
            //    .HasData(
            //        new DateCredit()
            //        {

            //            Year = "1401",
            //            Amount = 100000,
            //            IsEnable = false,
            //        },
            //        new DateCredit()
            //        {
            //            Year = "1402",
            //            Amount = 100000,
            //            IsEnable = true,
            //        }
            //    );
            //modelBuilder.Entity<Restaurant>().HasData(restuarant1, restuarant2, restuarant3);

            //modelBuilder.Entity<Factor>().HasData(factor1, factor2, factor3);
            //modelBuilder.Entity<Order>().HasData(oredr1, oredr2);
            ////modelBuilder.Entity<UserOrder>().HasData(userOrder1, userOrder2, userOrder3);

            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");

            base.OnModelCreating(modelBuilder);

        }
    }
}
