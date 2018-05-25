using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Software_Management_Course_Website.Controllers
{
    public class CoursesController : Controller
    {
        private Models.RootObject items;

        public CoursesController()
        {
            // Load JSON here
            using (StreamReader r = new StreamReader(@"Data/Smriti_Principles.json"))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<Models.RootObject>(json);
            }
        }

        public IActionResult Index()
        {
            return View(items);
        }
    }
}