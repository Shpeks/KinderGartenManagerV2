using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Entities.MenuModels;
using DAL.Entities.UserModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuFood> MenuFoods { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<MealTime> MealsTime { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .ToTable("Users");

            builder.Entity<IdentityRole>().
                ToTable("Roles");

            builder.Entity<IdentityUserRole<string>>()
                .ToTable("UserRoles");
            
            builder.Ignore<IdentityUserLogin<string>>();
            builder.Ignore<IdentityUserClaim<string>>();
            builder.Ignore<IdentityUserToken<string>>();
            builder.Ignore<IdentityRoleClaim<string>>();
            builder.Ignore<IdentityUser>();

            builder.Entity<Menu>()
                .HasOne(m => m.User)
                .WithMany(u => u.Menus)
                .HasForeignKey(m => m.UserId);

            builder.Entity<MenuFood>()
                .HasOne(mf => mf.Meal)
                .WithMany(m => m.MenuFoods)
                .HasForeignKey(mf => mf.MealId);

            builder.Entity<MenuFood>()
                .HasOne(mf => mf.MealTime)
                .WithMany(mt => mt.MenuFoods)
                .HasForeignKey(mf => mf.MealTimeId);

            builder.Entity<MenuFood>()
                .HasOne(mf => mf.Unit)
                .WithMany(u => u.MenuFoods)
                .HasForeignKey(mf => mf.UnitId);

            builder.Entity<MenuFood>()
                .HasOne(mf => mf.Menu)
                .WithMany(m => m.MenuFoods)
                .HasForeignKey(mf => mf.MenuId);

        }
    }
}
