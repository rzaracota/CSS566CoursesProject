using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursesAPI.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string Name { get; set; }
        public List<int> Modules { get; set; }
    }
}
