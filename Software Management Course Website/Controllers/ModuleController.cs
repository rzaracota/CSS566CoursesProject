using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using serviceclient;
using serviceclient.types;

namespace Software_Management_Course_Website.Controllers
{
    public class ModulesController : Controller
    {
        private Models.RootObject items;
        
        private static string endpoint = "http://localhost:1738/module";

        private ServiceClient<Module> client = new ServiceClient<Module>(endpoint);
    
        public List<Module> Modules { get; private set; } 

        public ModulesController()
        {
            client = new ServiceClient<Module>(endpoint);
        }

        public IActionResult Index()
        {
            var model = new ModulesViewModel();

            model.Modules = client.Get();

            return View(model);
        }
    }
}