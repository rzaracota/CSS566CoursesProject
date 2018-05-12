using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Api.Repo_Model {
    /**
     * References an image for a module.
     **/
    public class ModuleImageContent : ModuleBaseContent {
        public string Link { get; set; }
        public string Caption { get; set; }
    }
}
