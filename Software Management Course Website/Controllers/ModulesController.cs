using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

using serviceclient;
using serviceclient.types;
using Software_Management_Course_Website.Models;

namespace Software_Management_Course_Website.Controllers
{
    public class ModulesController : Controller
    {
        private static string endpoint =  "http://css566backend.azurewebsites.net/";

        private ServiceClient<serviceclient.types.Module> client = new ServiceClient<serviceclient.types.Module>(endpoint + "/course");

        private Models.Module items;

        private string Message { get; set; }

        public ModulesController(IConfiguration configuration)
        {
            // test for presence of keys
            endpoint = configuration["backendapi:uri"];
            Message = configuration["backendapi:message"];

            // Load JSON here
            using (StreamReader r = new StreamReader(@"Data/AgileGameDevelopmentModule.json"))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<Models.Module>(json);
            }

            items = new Models.Module();

            items.Module = client.Get().First();
        }

        public IActionResult Index()
        {
            return View(items);
        }
    }
}