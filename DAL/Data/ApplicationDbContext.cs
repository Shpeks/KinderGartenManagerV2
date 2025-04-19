using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Entities.MenuModels;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuFood> MenuFoods { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<MealTime> MealsTime { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
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

            base.OnModelCreating(builder);
        }
    }
}
