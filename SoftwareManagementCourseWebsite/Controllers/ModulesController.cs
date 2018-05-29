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
    [Route("module")]
    public class ModulesController : Controller
    {
        private static string endpoint =  "http://css566backend.azurewebsites.net/";

        private ServiceClient<Module> client = null;

        private string Message { get; set; }

        public ModulesController(IConfiguration configuration)
        {
            // test for presence of keys
            endpoint = configuration["backendapi:uri"];
            Message = configuration["backendapi:message"];

            if (endpoint.Last() == '/') {
                endpoint = endpoint.Substring(0, endpoint.Length - 1);
            }

            endpoint += "/module";

            client = new ServiceClient<Module>(endpoint);
        }

        public IActionResult Index()
        {
            var viewModel = new ModulesViewModel();
            
            viewModel.Modules = client.Get();

            return View(viewModel);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id) {
            var viewModel = new ModulesViewModel();

            viewModel.Module = client.Get(id);

            return View("Module", viewModel);
        }
    }
}