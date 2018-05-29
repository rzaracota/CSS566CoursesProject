using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Software_Management_Course_Website.Models
{
    public class CoursesDetailsViewModel
    {
        public Course Course { get; set; }
        public List<Module> Modules { get; set; }
    }
}
