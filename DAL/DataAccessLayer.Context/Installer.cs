using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace DataAccess.Context
{
    public static class Installer
    {
        public static void ConfigureDbContext(IServiceCollection services)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            services
                .AddDbContext<Context>(o => o
                   // .UseLazyLoadingProxies() // lazy loading
                .UseSqlServer(config.GetConnectionString("AdvertDb")));
        }
    }
}
