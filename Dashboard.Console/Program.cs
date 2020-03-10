using System;
using BusinesLogic.Services.Abstractions;
using BusinessLogic.Services;
using BusinessLogic.Services.Abstractions;
using DataAccess.Context;
using DataAccess.Repositories;
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
                .AddTransient<ICategoryService, CategoryService>()
                .AddTransient<ICategoryRepository, CategoriesRepository>()
                .BuildServiceProvider();
            System.Console.WriteLine("Hello World!");
            var P = serviceProvider.GetService<Context>();
            System.Console.ReadKey();
        }
    }
}
