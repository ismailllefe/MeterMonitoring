using DatabaseLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLibrary.Data
{
    public class MeterMonitoringContext : DbContext
    {
        public MeterMonitoringContext(DbContextOptions<MeterMonitoringContext> options)
            : base(options) { }

        public DbSet<MeterData> Meters { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Meter>().HasKey(m => m.Id); 
        //    modelBuilder.Entity<Meter>()
        //                .Property(m => m.SerialNumber)
        //                .HasMaxLength(8) 
        //                .IsRequired();
        //}
    }
}