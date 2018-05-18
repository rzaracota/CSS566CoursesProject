using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Api.Repo_Model {
    /**
     * References an image for a module.
     **/
    public class ModuleImageContent : ModuleBaseContent {
        /**
         * Constructs a new ModuleImageContent.
         **/
        public ModuleImageContent() {
            Type = "image";
        }

        [JsonProperty(PropertyName = "Link")]
        public string Link { get; set; }

        [JsonProperty(PropertyName = "Caption")]
        public string Caption { get; set; }
    }
}
