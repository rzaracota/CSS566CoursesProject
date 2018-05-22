using Backend_Api.Repository;
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
            Layout = new List<ModuleBaseContent>();
            Doctype = "Module";
        }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "ModuleId")]
        public string ModuleId { get; set; }

        [JsonProperty(PropertyName = "Title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "Author")]
        public string Author { get; set; }

        [JsonProperty(PropertyName = "CourseModule")]
        [JsonConverter(typeof(SingleOrArrayConverter<CourseModule>))]
        public List<CourseModule> CourseModules { get; set; }

        [JsonProperty(PropertyName = "Layout")]
        [JsonConverter(typeof(ModuleBaseTypeConverter))]
        public List<ModuleBaseContent> Layout { get; set; }

        [JsonProperty(PropertyName = "Doctype")]
        public string Doctype { get; set; }
    }
}
