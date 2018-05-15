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

        public string Id { get; set; }
        public string Heading { get; set; }
        public string Type { get; set; }
        public string Text { get; set; }
    }
}
