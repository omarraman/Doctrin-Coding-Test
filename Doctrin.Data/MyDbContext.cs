using Doctrin.Core.Entities;
using Doctrin.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Doctrin.Data
{
    public class MyDbContext: DbContext
    {
        //public DbSet<Calendar> Calendars { get; set; }
        //public DbSet<ExceptionDay> ExceptionDays { get; set; }
        //public DbSet<ExceptionSetting> ExceptionSettings { get; set; }
        //public DbSet<Setting> Settings { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Setting> Settings { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UnitConfiguration());
            modelBuilder.ApplyConfiguration(new SettingConfiguration());

            ////disable indentity to maintain referential integrity 
            //UomInitializer.Execute(modelBuilder);
            //FoodInitializer.Execute(modelBuilder);
            //DayAndMealInitializer.Execute(modelBuilder);



            //modelBuilder.Entity<MealRecipeItem>().HasKey(k => new { k.MealId, k.RecipeId });




        }

        //public static readonly Microsoft.Extensions.Logging.LoggerFactory _myLoggerFactory =
        //    new LoggerFactory(new[] {
        //        new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider()
        //    });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseLoggerFactory(_myLoggerFactory);
        }

        public MyDbContext(
    DbContextOptions<MyDbContext> options)
    : base(options) { }
    }






}
