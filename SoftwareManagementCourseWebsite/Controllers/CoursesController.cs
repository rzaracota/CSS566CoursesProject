using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using serviceclient;
//using serviceclient.types;
using Software_Management_Course_Website.Models;

namespace Software_Management_Course_Website.Controllers
{
    public class CoursesController : Controller
    {
        private Course items;
        
        private static string endpoint = "http://css566backend.azurewebsites.net/";

        private ServiceClient<Course> coursesClient = null;
        private ServiceClient<Module> moduleClient = null;
    
        public List<Course> Courses { get; private set; } 

        public string Message { get; set; }

        public CoursesController(IConfiguration configuration)
        {
            // test for presence of keys
            endpoint = configuration["backendapi:uri"];
            Message = configuration["backendapi:message"];

            if (endpoint.Last() == '/')
            {
                endpoint = endpoint.Substring(0, endpoint.Length - 1);
            }

            //endpoint += "/course";
            string courseEndpoint = endpoint + "/course";
            string moduleEndpoint = endpoint + "/module";

            coursesClient = new ServiceClient<Course>(courseEndpoint);
            moduleClient = new ServiceClient<Module>(moduleEndpoint);
        }

        public IActionResult Index()
        {
            var model = new CoursesViewModel();

            model.Courses = coursesClient.Get();
            model.Message = string.IsNullOrEmpty(Message) ? "message not set" : Message;

            return View(model);
        }

        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CoursesDetailsViewModel vm = new CoursesDetailsViewModel();

            Course course = coursesClient.Get(id);
            vm.Course = course;

            vm.Modules = new List<Module>();

            foreach(int modelID in course.Modules)
            {
                Module temp = moduleClient.Get(modelID.ToString());
                vm.Modules.Add(temp);
            }

            return View(vm);
            
        }
    }
}