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
            CourseModules = new List<CourseModule>();
        }
        [JsonProperty(PropertyName = "CourseId")]
        public string CourseId { get; set; }

        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "CourseModules")]
        public List<CourseModule> CourseModules { get; set; }
    }
}
