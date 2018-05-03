using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuleAPI.Models
{
    public class Module
    {
        public int ModuleID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
    }
}
