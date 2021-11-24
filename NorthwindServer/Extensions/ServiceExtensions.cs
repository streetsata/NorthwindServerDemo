using Contracts;
using Entities;
using LoggerService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Repository;
using System.Reflection;
using System.IO;
using System;

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

        public static void ConfigureLocalDBContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["LocalDBConnection:connectionString"];
            
            if (connectionString == null)
                return;

            services.AddDbContext<RepositoryContext>(o => o.UseSqlServer(connectionString));
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "My Northwind API",
                    Version = "v1",
                    Description = "Northwind service",
                    TermsOfService = new System.Uri("https://www.google.com/terms"),
                    License = new Microsoft.OpenApi.Models.OpenApiLicense
                    {
                        Name = "My Lic", // url <> uri
                        Url = new System.Uri("https://www.google.com/lic")
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var path = Path.Combine(AppContext.BaseDirectory, xmlFile);

                c.IncludeXmlComments(path);
            });
        }
    }
}
