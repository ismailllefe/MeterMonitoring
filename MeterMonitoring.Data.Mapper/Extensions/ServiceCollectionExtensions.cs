using MeterMonitoring.Data.Mapper.Maps;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterMonitoring.Data.Mapper.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(config => {
                config.AddProfile(new MappingProfile());
            });
        }
    }
}