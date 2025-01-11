using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Utilities.Enum;
using Utilities;

namespace Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //var adminRoleId = new Guid("254a86dd-3e41-45b8-bb91-f97ee3b17c70");
            //var userRoleId = new Guid("a0d68896-6e89-46a4-a9e7-2b0aa17edc97");
            //var adminUserId = new Guid("aac63b91-beb8-4de4-b050-f2888fdff282");

            //// Seed roles
            //modelBuilder.Entity<Roles>().HasData(
            //    new Roles { Id = adminRoleId, RoleName = "Admin" },
            //    new Roles { Id = userRoleId, RoleName = "User" }
            //);

            //modelBuilder.Entity<Users>().HasData(
            //    new Users
            //    {
            //        Id = adminUserId,
            //        UserName = "admin",
            //        FirstName = "Tri",
            //        LastName = "Tran",
            //        Code = "AD-01",
            //        IdentityCard = "12345",
            //        IdentityCardAddress = "Binh Phuoc",
            //        IdentityCardDate = new DateTime(2015, 12, 25),
            //        Phone = "0333444555",
            //        RefreshToken = null,
            //        FullName = "Tran Huu Tri",
            //        Password = SecurityUtilities.HashSHA1("23312331"), //hashed password
            //        Email = "admin@gmail.com",
            //        Address = "Binh Phuoc",
            //        IsActive = true,
            //        Deleted = false,
            //        IsAdmin = true,
            //        Created = DateTime.UtcNow.AddHours(7),
            //        CreatedBy = Guid.Empty,
            //        Status = (int)UserStatus.Active,
            //        Gender = (int)UserGender.Female
            //    }
            //);

            //modelBuilder.Entity<UserRoles>().HasData(
            //    new UserRoles
            //    {
            //        Id = new Guid("76fc0760-be56-4c90-b09c-fde6436050f9"),
            //        UsersId = adminUserId,
            //        RolesId = adminRoleId
            //    }
            //);
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Jewelry> Jewelries { get; set; }
<<<<<<< Updated upstream
=======
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<InventoryDetails> InventoryDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

>>>>>>> Stashed changes
    }
}
