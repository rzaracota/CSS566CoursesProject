using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Api.Repo_Model {
    /**
     * A component of a course to be completed.
     **/
    public class Module {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public List<Course> Courses { get; set; }
        public List<ModuleBaseContent> Layout { get; set; }
    }
}
