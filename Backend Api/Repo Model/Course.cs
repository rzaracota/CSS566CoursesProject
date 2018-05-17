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
            CourseModules = new List<CourseModule>();
            Doctype = "Course";
        }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "CourseId")]
        public string CourseId { get; set; }

        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "CourseModules")]
        [JsonConverter(typeof(SingleOrArrayConverter<CourseModule>))]
        public List<CourseModule> CourseModules { get; set; }

        [JsonProperty(PropertyName = "Doctype")]
        public string Doctype { get; set; }
    }
}
