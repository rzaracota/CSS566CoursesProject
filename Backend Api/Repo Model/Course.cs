using Backend_Api.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Api.Repo_Model {
    /**
     * A course which contains a sequence of modules to be
     * completed.
     **/
    public class Course {
        public Course()
        {
            Doctype = "Course";
        }
       
        public string Id { get; set; }
        public string CourseId { get; set; }
        public string Name { get; set; }
        public List<string> ModuleIds { get; set; }
        public string Doctype { get; set; }
    }
}
