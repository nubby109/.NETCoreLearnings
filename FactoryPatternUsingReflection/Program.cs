using FactoryPatternUsingReflection.FactoryUtility;
using FactoryPatternUsingReflection.ShapeFactory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace FactoryPatternUsingReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create the configuration required for the app
            //Reading the config from a json file
            IConfiguration configuration = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            //Create service collection and configure our services
            var services = ConfigureServices(configuration);

            //Build a ServiceProvider
            var serviceProvider = services.BuildServiceProvider();

            //Run the program
            serviceProvider.GetService<ExecuteProgam>().Run();
        }


        private static IServiceCollection ConfigureServices(IConfiguration configuration)
        {
            //Create a DI container and add objects to it
            IServiceCollection services = new ServiceCollection();
            services.Configure<LoggerFilterOptions>(configuration);
            services.AddLogging(opt =>
            {
                opt.AddConfiguration(configuration.GetSection("Logging"));
                opt.AddConsole();
            });
/*            services.AddLogging(config => config.AddConsole());
*/
            services.AddTransient<Circle>();
            services.AddTransient<Rectangle>();
            services.AddTransient<Square>();
            services.AddTransient<IBaseFactory<IShape>, ShapeTypeFactory>();
            services.AddTransient<ExecuteProgam>();
            

            return services;
        }

    }
}
