using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Api.Repo_Model {
    /**
     * Contains common fields for module content.
     **/
    public class ModuleBaseContent {
        public string Id { get; set; }
        public string Heading { get; set; }
        public string Type { get; set; }
        public string CourseId { get; set; }
    }
}
