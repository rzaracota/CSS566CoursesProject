using System.Collections.Generic;
//using serviceclient.types;

namespace Software_Management_Course_Website.Models
{

    public class CoursesViewModel
    {
        public List<Course> Courses { get; set; }
        public string Message { get; set; }
        public List<Module> Modules { get; set; }
    }
}