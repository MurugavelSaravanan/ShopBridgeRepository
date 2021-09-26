using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopBridge.Backend.API.Services;
using ShopBridge.Backend.Data.Repositories;
using ShopBridge.Data;
using System;
using System.Collections.Generic;
using System.Text;

[assembly: FunctionsStartup(typeof(ShopBridge.Backend.API.Startup))]
namespace ShopBridge.Backend.API
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            string connectionString = Environment.GetEnvironmentVariable("ConnectionString");
            builder.Services.AddDbContext<ShopBridgeDbContext>(
                options => SqlServerDbContextOptionsExtensions.UseSqlServer(options, connectionString));
            RegisterRepositories(builder);
            RegisterServices(builder);
        }

        //Method to register services
        private void RegisterServices(IFunctionsHostBuilder builder)
        {
            builder.Services.AddTransient<IService, Service>();
        }

        //Method to register repositories
        private void RegisterRepositories(IFunctionsHostBuilder builder)
        {
            builder.Services.AddTransient<IItemDetailsRepository, ItemDetailsRepository>();
        }
    }
}
