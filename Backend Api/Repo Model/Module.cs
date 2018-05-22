﻿using Backend_Api.Repository;
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
            CourseIds = new List<string>();
            Layout = new List<ModuleBaseContent>();
            Doctype = "Module";
        }

        [JsonIgnore]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "ModuleId")]
        public string ModuleId { get; set; }

        [JsonProperty(PropertyName = "Title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "Author")]
        public string Author { get; set; }

        [JsonProperty(PropertyName = "CourseIds")]
        public List<string> CourseIds { get; set; }

        [JsonProperty(PropertyName = "Layout")]
        [JsonConverter(typeof(ModuleBaseTypeConverter))]
        public List<ModuleBaseContent> Layout { get; set; }

        [JsonIgnore]
        public string Doctype { get; set; }
    }
}
