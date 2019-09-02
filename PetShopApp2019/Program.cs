using Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using PetShop.Core.ApplicationService;
using PetShop.Core.ApplicationService.Service;
using PetShop.Core.DomainService;
using System;

namespace PetShopApp2019
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.AddScoped<IConsoleMenu, ConsoleMenu>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var menu = serviceProvider.GetRequiredService<IConsoleMenu>();
            menu.Run();
        }
    }
}
