using System.Threading.Tasks;
using BusinessLogic.Services.Abstractions;
using BusinessLogic.Services;
using BusinessLogic.Services.Abstractions;
using BusinessLogic.Services.Mapping;
using DataAccess.Context;
using DataAccess.Repositories;
using DataAccess.Repositories.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

namespace Dashboard.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var services = new ServiceCollection();
            Installer.ConfigureDbContext(services);

            services.AddAutoMapper(typeof(ServiceMappings));

            var serviceProvider = services
                .AddTransient<IAdvertisementService, AdvertisementService>()
                .AddTransient<ICategoryService, CategoryService>()
                .AddTransient<ICategoryRepository, CategoriesRepository>()
                .AddTransient<ICommentRepository, CommentsRepository>()
                .AddTransient<IAdvertisementRepository, AdvertisementRepository>()
                .BuildServiceProvider();
            System.Console.WriteLine("Hello World!");
            var P = serviceProvider.GetService<Context>();
            System.Console.ReadKey();
        }
    }
}
