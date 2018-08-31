using Microsoft.Extensions.DependencyInjection;
using PetShop.ConsoleApp.Core.Application_Service;
using PetShop.ConsoleApp.Core.Domain_Service;
using PetShop.ConsoleApp.Repository.Repository;
using System;

namespace PetShop.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.AddScoped<IPrinter, Printer>();

            ////then build provider 
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var printer = serviceProvider.GetRequiredService<IPrinter>();
            printer.StartUI();
        }
    }
}
