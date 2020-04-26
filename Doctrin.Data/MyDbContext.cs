using Doctrin.Core.Entities;
using Doctrin.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Doctrin.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<Unit> Units { get; set; }
        public DbSet<Setting> Settings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UnitConfiguration());
            modelBuilder.ApplyConfiguration(new SettingConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public MyDbContext(
    DbContextOptions<MyDbContext> options)
    : base(options) { }
    }






}
