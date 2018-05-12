using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Api.Repo_Model {
    /**
     * Contains text content for a module.
     **/
    public class ModuleTextContent : ModuleBaseContent {
        /**
         * Constructs a new ModuleTextContent.
         **/
        public ModuleTextContent() {
            Type = "text";
        }

        public string Text { get; set; }
    }
}
