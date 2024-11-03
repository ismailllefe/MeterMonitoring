using MeterMonitoring.Rabbit.Consumer.Managers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Globalization;
using System.Security.AccessControl;
using System;
using DatabaseLibrary.Data;
using Microsoft.EntityFrameworkCore;
using MeterMonitoring.Rabbit.Consumer.Helpers;

namespace MeterMonitoring.Rabbit.Consumer
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
              .ConfigureServices((context, services) =>
              {
                  services.AddHostedService<RequestConsumerManager>();

                  //var connectionString = context.Configuration.GetConnectionString("PostgresConnection");
                  services.AddDbContext<MeterMonitoringContext>(options =>
                      options.UseNpgsql("Host=localhost;Port=5432;Database=meterdb;User ID=solarbitadbowner;Password=1q2w3e4R!"));
                  services.AddScoped<ReportHelper>();
              })
              .Build();

            host.Run();

        }
    }
}
