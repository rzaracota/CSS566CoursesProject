using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using serviceclient;
using serviceclient.types;

namespace Software_Management_Course_Website.Controllers
{
    public class CoursesController : Controller
    {
        private Models.Course items;
        
        private static string endpoint = "http://css566backend.azurewebsites.net/";

        private ServiceClient<Course> client = null;
    
        public List<Course> Courses { get; private set; } 

        public string Message { get; set; }

        public CoursesController(IConfiguration configuration)
        {
            // test for presence of keys
            endpoint = configuration["backendapi:uri"];
            Message = configuration["backendapi:message"];

            client = new ServiceClient<Course>(endpoint + "/course");
        }

        public IActionResult Index()
        {
            var model = new CoursesViewModel();

            model.Courses = client.Get();
            model.Message = string.IsNullOrEmpty(Message) ? "message not set" : Message;

            return View(model);
        }

        //            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            //return View("~/Views/Courses.cshtml");
    }
}