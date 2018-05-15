using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Api.Repo_Model {
    /**
     * A component of a course to be completed.
     **/
    public class Module {
        public Module()
        {
            CourseModules = new List<CourseModule>();
            Layout = new List<ModuleTextContent>();
        }

        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public List<CourseModule> CourseModules { get; set; }
        public List<ModuleTextContent> Layout { get; set; }
    }
}
