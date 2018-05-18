using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Api.Repo_Model {
    /**
     * References a quiz for a module.
     **/
    public class ModuleQuizContent : ModuleBaseContent {
        /**
         * Constructs a new ModuleQuizContent.
         **/
        public ModuleQuizContent() {
            Type = "quiz";
        }

        [JsonProperty(PropertyName = "Link")]
        public string Link { get; set; }
    }
}
