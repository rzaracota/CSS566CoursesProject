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
            Doctype = "Module";
        }
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public string ModuleId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public List<string> CourseIds { get; set; }
        public List<string> Keywords { get; set; }
        [JsonConverter(typeof(ModuleBaseTypeConverter))]
        public List<ModuleBaseContent> Layout { get; set; }
        public string Doctype { get; set; }
    }
}
