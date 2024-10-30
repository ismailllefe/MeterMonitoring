using Microsoft.EntityFrameworkCore;
using DatabaseLibrary.Models;

namespace DatabaseLibrary.Data
{
    public class MeterMonitoringContext : DbContext
    {
        // Constructor: DbContext yapılandırmasını dışarıdan alır
        public MeterMonitoringContext(DbContextOptions<MeterMonitoringContext> options)
            : base(options) { }

        // MeterReadings tablosunu temsil eden DbSet
        public DbSet<MeterMonitoring> MeterReadings { get; set; }

        // Veritabanı yapılandırması için OnModelCreating metodu
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MeterMonitoring>().HasKey(m => m.Id); // UUID'yi anahtar yap
            modelBuilder.Entity<MeterMonitoring>()
                        .Property(m => m.SerialNumber)
                        .HasMaxLength(8) // Seri numarası maksimum 8 karakter
                        .IsRequired(); // Boş bırakılamaz
        }
    }
}