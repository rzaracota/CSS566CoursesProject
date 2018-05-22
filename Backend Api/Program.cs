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
            Course course1 = new Course
            {
                CourseId = "1",
                Name = "John Doe's course",
            };

            Module module1 = new Module
            {
                ModuleId = "987",
                Author = "John Doe",
                Title = "Agile Development",
                Layout = new List<ModuleBaseContent>
                {
                    new ModuleTextContent
                    {
                        Heading = "Motivation for Agile",
                        Text = "This is why we want to do Agile"
                    },
                    new ModuleImageContent
                    {
                        Link = "MyImageLink",
                        Caption = "MyImageCaption"
                    },
                    new ModuleVideoContent
                    {
                        Link = "MyVideoLink",
                        Caption = "MyVideoCaption"
                    },
                    new ModuleQuizContent
                    {
                        Link = "MyQuizLink"
                    }
                }
            };

            CourseModule courseModule1 = new CourseModule
            {
                CourseId = course1.CourseId,
                ModuleId = module1.ModuleId,
            };

            course1.CourseModules.Add(courseModule1);
            module1.CourseModules.Add(courseModule1);

            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    IModuleRepository moduleRepository
                        = services.GetRequiredService<IModuleRepository>();
                    moduleRepository.CreateModule(module1);

                    ICourseRepository courseRepository
                        = services.GetRequiredService<ICourseRepository>();
                    courseRepository.CreateCourse(course1);
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
                .UseApplicationInsights()
                .UseStartup<Startup>()
                .Build();
    }
}
