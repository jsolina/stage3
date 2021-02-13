using Domain.Contracts;
using Infrastracture.Persistence;
using Infrastracture.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAppAPI.Extension
{
    public static class ServiceExtension
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(o => { });
        }

        //public static void ConfigureLoggerService(this IServiceCollection services)
        //{
        //    services.AddSingleton<ILoggerManager, LoggerManager>();
        //}

        public static void ConfigureMysqlContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["mysqlconnection:connectionString"];
            services.AddDbContext<DatabaseContext>(o => o.UseMySql(connectionString));
        }
        public static void ConfigureRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<ITaskList, TaskListRepo>();
            services.AddScoped<IItemList, ItemListRepo>();

            services.AddScoped<IDatabaseContext, DatabaseContext>();
        }
    }
}
