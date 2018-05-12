using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Api.Repo_Model {
    /**
     * Contains a Course-Module mapping.
     **/
    public class CourseModule {
        public string CourseId { get; set; }
        public Course Course { get; set; }

        public string ModuleId { get; set; }
        public Module Module { get; set; }
    }
}
