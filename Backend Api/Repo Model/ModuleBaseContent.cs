using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Api.Repo_Model {
    /**
     * Contains common fields for module content.
     **/
    public class ModuleBaseContent {
        [JsonProperty(PropertyName = "Heading")]
        public string Heading { get; set; }

        [JsonProperty(PropertyName = "Type")]
        public string Type { get; set; }
    }
}
