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
            ModuleIds = new List<string>();
            Doctype = "Course";
        }

        [JsonIgnore]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "CourseId")]
        public string CourseId { get; set; }

        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "ModuleIds")]
        public List<string> ModuleIds { get; set; }

        [JsonIgnore]
        public string Doctype { get; set; }
    }
}
