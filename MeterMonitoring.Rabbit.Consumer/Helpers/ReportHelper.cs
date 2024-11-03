using DatabaseLibrary.Data;
using System.Text.Json;

namespace MeterMonitoring.Rabbit.Consumer.Helpers
{
    public class ReportHelper
    {
        private readonly MeterMonitoringContext context;

        public ReportHelper(MeterMonitoringContext context)
        {
            this.context = context;
        }

        public async Task CreateReportContent(string serialNumber)
        {
            var report = context.Reports.Where(r => r.SerialNumber == serialNumber && r.RequestState != Library.Enums.RequestState.Ready).FirstOrDefault();
            if (report is null)
            {
                return;
            }

            report.Content = GenerateReportContent(serialNumber);
            context.Reports.Update(report);

            var result = await context.SaveChangesAsync();
            if (result <= 0)
            {
                return;
            }

        }

        private string GenerateReportContent(string serialNumber)
        {
            var measurements = context.Meters
                .Where(m => m.SerialNumber == serialNumber)
                .OrderByDescending(m => m.ReadingTime)
                .Select(m => new
                {
                    m.ReadingTime,
                    m.LastIndex,
                    m.Voltage,
                    m.Current
                })
                .ToList();

            var reportContent = new
            {
                ReportDate = DateTime.Now,
                MeasurementSummary = measurements
            };

            return JsonSerializer.Serialize(reportContent);
        }
    }
}
