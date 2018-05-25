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

namespace Software_Management_Course_Website.Controllers
{
    public class ModulesController : Controller
    {
        private static string endpoint =  "http://css566backend.azurewebsites.net/";

        private ServiceClient<Module> client = null;

        private Models.RootObject items;

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
                items = JsonConvert.DeserializeObject<Models.RootObject>(json);
            }

            if (endpoint.Last() == '/') {
                endpoint = endpoint.Substring(0, endpoint.Length - 1);
            }

            endpoint += "/module";

            client = new ServiceClient<Module>(endpoint);

            items.Module = client.Get().First();
        }

        public IActionResult Index()
        {
            items.Module = client.Get().First();

            return View(items);
        }
    }
}