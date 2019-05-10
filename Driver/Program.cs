using Microsoft.Extensions.Configuration;
using PeopleService;
using System;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace Driver
{
    /// <summary>
    /// Main driver program for the test
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            try
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

                IConfigurationRoot configuration = builder.Build();

                var peopleServiceBaseUrl = configuration["PeopleServiceBaseUrl"];
                var peopleServiceClient = new PeopleServiceClient(peopleServiceBaseUrl);

                var peopleModel = await peopleServiceClient.GetPeopleAsync();

                var view = new PeopleConsoleView(peopleModel);

                view.Render();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("\nHit any key to finish...");
            Console.ReadKey();
        }
    }
}
