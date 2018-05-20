using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Software_Management_Course_Website.Controllers
{
    public class TrainingContentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}