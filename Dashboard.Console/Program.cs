using System;
using BusinesLogic.Services.Abstractions;
using BusinessLogic.Services;
using DataAccess.Context;
using DataAccess.Repositories.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Dashboard.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            Installer.ConfigureDbContext(services);
            var serviceProvider = services
                .AddTransient<IAdvertisementService, AdvertisementService>()
                .BuildServiceProvider();
            System.Console.WriteLine("Hello World!");
            var P = serviceProvider.GetService<Context>();
            System.Console.ReadKey();
        }
    }
}
