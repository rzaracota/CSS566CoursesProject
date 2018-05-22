using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Software_Management_Course_Website.Models
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ModuleModel
    {

        public string Id { get; set; }
        public string Title { get; set; }
        public string HtmlContent { get; set; }
        public string Version { get; set; }
    }

}
