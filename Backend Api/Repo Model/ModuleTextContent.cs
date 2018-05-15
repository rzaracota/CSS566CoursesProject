using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Api.Repo_Model {
    /**
     * Contains text content for a module.
     **/
    public class ModuleTextContent {
        /**
         * Constructs a new ModuleTextContent.
         **/
        public ModuleTextContent() {
            Type = "text";
        }

        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "Heading")]
        public string Heading { get; set; }

        [JsonProperty(PropertyName = "Type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "Text")]
        public string Text { get; set; }
    }
}
