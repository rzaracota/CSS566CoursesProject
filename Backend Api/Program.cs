using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Backend_Api.Repo_Model;
using Backend_Api.Repository;

namespace Backend_Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // add initial fake data for testing
            Module module1 = new Module
            {
                Id = "123",
                Author = "John Doe",
                Title = "Agile Development",
                Layout = new List<ModuleBaseContent>
                {
                    new ModuleTextContent
                    {
                        Heading = "Motivation for Agile",
                        Text = "This is why we want to do Agile"
                    }
                }
            };            

            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    IModuleRepository moduleRepository
                        = services.GetRequiredService<IModuleRepository>();
                    moduleRepository.CreateModule(module1);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
