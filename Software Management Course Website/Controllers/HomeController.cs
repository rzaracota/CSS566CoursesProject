using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Software_Management_Course_Website.Models;
using serviceclient;
using Microsoft.Extensions.Configuration;

namespace Software_Management_Course_Website.Controllers
{
    public class HomeController : Controller
    {
        private static string endpoint = "http://css566backend.azurewebsites.net";

        private ServiceClient<Course> client;
        

        public HomeController(IConfiguration configuration)
        {
            endpoint = configuration["backendapi:uri"];

            if (endpoint.Last() == '/')
            {
                endpoint = endpoint.Substring(0, endpoint.Length - 1);
            }

            endpoint += "/course";

            client = new ServiceClient<Course>(endpoint);
        }

        public IActionResult Index()
        {
            HomeViewModel vm = new HomeViewModel();

            vm.Courses = client.Get();

            return View(vm);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
