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

        public string Link { get; set; }
        public string Caption { get; set; }
    }
}
