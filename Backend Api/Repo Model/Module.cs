using Newtonsoft.Json;
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

        [JsonProperty(PropertyName = "ModuleId")]
        public string ModuleId { get; set; }

        [JsonProperty(PropertyName = "Title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "Author")]
        public string Author { get; set; }

        [JsonProperty(PropertyName = "CourseModule")]
        public List<CourseModule> CourseModules { get; set; }

        [JsonProperty(PropertyName = "Layout")]
        public List<ModuleTextContent> Layout { get; set; }
    }
}
