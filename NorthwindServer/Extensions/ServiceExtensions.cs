using Contracts;
using LoggerService;
using Microsoft.Extensions.DependencyInjection;

namespace NorthwindServer.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(o =>
            {
                o.AddPolicy("MyCorsPolicy",
                    b => b.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    );
            }
            );
        }

        public static void ConfigureLogger(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }
    }
}
