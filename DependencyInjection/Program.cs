using DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    private static void Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();
        ConfigurationServices(serviceCollection);

        var serviceProvider = serviceCollection.BuildServiceProvider();

        var myCustomerService = serviceProvider.GetService<ICustomerService>();
        //populate customers first
        myCustomerService.PopulateCustomers();
        var customer = myCustomerService.GetCustomerById(1);

        Console.WriteLine($"Customer Name with Id {customer.Id} is {customer.Name}");

    }


    private static void ConfigurationServices(IServiceCollection services)
    {
        services.AddTransient<ICustomerService,CustomerService>();
    }
}