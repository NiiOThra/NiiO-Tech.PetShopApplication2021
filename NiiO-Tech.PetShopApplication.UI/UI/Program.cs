using Microsoft.Extensions.DependencyInjection;
using NiiO_Tech.PetShopApplication2021.Core.IServices;
using NiiO_Tech.PetShopApplication2021.Domain.IRepositories;
using NiiO_Tech.PetShopApplication2021.Domain.Services;
using NiiO_Tech.PetShopApplication2021.Infrastructure.Data.Repositories;

namespace NiiO_Tech.PetShopApplication.UI
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPetTypeRepository, PetTypeRepository>();
            
            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.AddScoped<IPetTypeService, PetTypeService>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var petService = serviceProvider.GetRequiredService<IPetService>();

            var petTypeService = serviceProvider.GetRequiredService<IPetTypeService>();

            var startUp = new Menu(petService, petTypeService);
            startUp.StartData();
            startUp.Start();
        }
    }
}