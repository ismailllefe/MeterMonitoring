using MediatR;
using MeterMonitoring.Data.Services.Abstractions;
using MeterMonitoring.Data.Services.Concretes;
using Microsoft.Extensions.DependencyInjection;

namespace MeterMonitoring.Data.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services)
        {
            SetupMediatR(services);
            services.AddScoped<IMeterService, MeterService>();
            services.AddScoped<IReportService, ReportService>();
            return services;
        }
        private static void SetupMediatR(IServiceCollection services)
        {
            var meterQueryAssembly = AppDomain.CurrentDomain.Load("MeterMonitoring.Meter.Queries");
            var meterCommandAssembly = AppDomain.CurrentDomain.Load("MeterMonitoring.Meter.Commands");

            services.AddMediatR(meterQueryAssembly, meterCommandAssembly);
        }
    }
}
