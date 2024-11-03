using DatabaseLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLibrary.Data
{
    public class MeterMonitoringContext : DbContext
    {
        public MeterMonitoringContext(DbContextOptions<MeterMonitoringContext> options)
            : base(options) { }

        public DbSet<MeterData> Meters { get; set; }

        public DbSet<Report> Reports { get; set; }
    }
}