using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Api.Repo_Model {
    /**
     * References a video for a module.
     **/
    public class ModuleVideoContent : ModuleBaseContent {
        /**
         * Constructs a new ModuleVideoContent.
         **/
        public ModuleVideoContent() {
            Type = "video";
        }

        [JsonProperty(PropertyName = "Link")]
        public string Link { get; set; }

        [JsonProperty(PropertyName = "Caption")]
        public string Caption { get; set; }
    }
}
